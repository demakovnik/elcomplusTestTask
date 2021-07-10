using System.Collections.Generic;
using System.Xml.Serialization;

namespace XMLJSON.Deserializers.Xml
{
    [XmlRoot(ElementName = "Values")]
	public class Values
	{

		[XmlElement(ElementName = "Value")]
		public List<string> Value { get; set; }
	}

	[XmlRoot(ElementName = "Root")]
	public class XmlRoot:Root
	{

		[XmlElement(ElementName = "Values")]
		public Values Values { get; set; }

		[XmlAttribute(AttributeName = "xsi")]
		public string Xsi { get; set; }

		[XmlAttribute(AttributeName = "xsd")]
		public string Xsd { get; set; }

		[XmlText]
		public string Text { get; set; }

        public List<string> getValues()
        {
			return this.Values.Value;
        }
    }
}
