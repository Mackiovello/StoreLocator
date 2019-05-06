using System.Collections.Generic;
using System.Xml.Serialization;

namespace StoreLocator.Models
{
    [XmlRoot(ElementName = "stores")]
    public class Stores
    {
        [XmlElement(ElementName = "store")]
        public List<Store> AllStores { get; set; }
    }
}
