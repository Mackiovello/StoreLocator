using StoreLocator.Models;
using System.Collections.Generic;

namespace StoreLocator.Domain
{
    public interface IStoresDeserializer
    {
        Stores Deserialize();
    }
}
