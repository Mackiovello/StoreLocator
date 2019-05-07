using StoreLocator.Models;
using StoreLocator.Models.Xml;
using System.Collections.Generic;

namespace StoreLocator.Data
{
    public interface IStoresDeserializer
    {
        Stores Deserialize();
    }
}
