using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using XMLJSON.Deserializers;
using XMLJSON.Deserializers.Json;
using XMLJSON.Deserializers.Xml;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;
using System;
using System.Linq;

namespace XMLJSON
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private TextBlock myTextBlockResult;
        private TextBlock myTextBlockPath;
        private Dictionary<string, int> myDictionary;
        private Deserializer deserializer;
        private CommonOpenFileDialog openDirectoryDialog;
        private string directoryPath;
        private StreamReader streamReader;
        private Root root;

        public MainWindow()
        {
            InitializeComponent();
            myTextBlockResult = (TextBlock)Application.Current.MainWindow.FindName("textBlockResult");
            myTextBlockPath = (TextBlock) Application.Current.MainWindow.FindName("textBlockPath");
            directoryPath = "";
            openDirectoryDialog = new CommonOpenFileDialog();
            openDirectoryDialog.IsFolderPicker = true;
        }

        private void addFolderButton_Click(object sender, RoutedEventArgs e)
        {
            if (openDirectoryDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                directoryPath = openDirectoryDialog.FileName;
            }
            myTextBlockPath.Text = directoryPath;

        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (directoryPath != "") {
                var files = Directory.GetFiles(directoryPath);
                StringBuilder stringBuilder = new StringBuilder();
                string line;
                List<string> resultList = new List<string>();
                foreach(string file in files)
                {
                    streamReader = new StreamReader(file);
                    line = streamReader.ReadLine();
                    //Continue to read until you reach end of file
                    while (line != null)
                    {
                        //write the lie to console window
                        stringBuilder.Append(line);
                        //Read the next line
                        line = streamReader.ReadLine();
                    }
                    //close the file
                    streamReader.Close();
                    if (file.EndsWith("json"))
                    {
                        deserializer = new JsonDeserializer();
                    } else if(file.EndsWith("xml"))
                    {
                        deserializer = new XMLDeserializer();
                    }
                    var root = deserializer.getDeserializedObject(stringBuilder.ToString());
                    stringBuilder.Clear();
                    foreach(string result in root.getValues())
                    {
                        resultList.Add(result);
                    }
                }
                myDictionary = resultList.GroupBy(g => g).Select(s => new { Key = s.Key, Count = s.Count() }).ToDictionary(d => d.Key, d => d.Count);
                int maxValue = myDictionary.Max(pair => pair.Value);
                myDictionary = myDictionary.Where(pair => pair.Value==maxValue).ToDictionary(pair=>pair.Key,pair=>pair.Value);
                StringBuilder resultStringBuilder = new StringBuilder();
                foreach(string s in myDictionary.Keys)
                {
                    resultStringBuilder.Append(s).Append("-").Append(maxValue).Append(" counts");
                }
                myTextBlockResult.Text = resultStringBuilder.ToString();
                resultStringBuilder.Clear();
                
                
            }
        }
    }
}
