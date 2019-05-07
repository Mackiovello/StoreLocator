using System.Xml.Serialization;

namespace StoreLocator.Models.Xml
{
    [XmlRoot(ElementName = "store")]
    public class Store
    {
        [XmlElement(ElementName = "id")]
        public string Id { get; set; }

        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        [XmlElement(ElementName = "longitude")]
        public string Longitude { get; set; }

        [XmlElement(ElementName = "latitude")]
        public string Latitude { get; set; }
    }
}
