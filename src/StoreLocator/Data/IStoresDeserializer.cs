using StoreLocator.Models.Xml;

namespace StoreLocator.Data
{
    public interface IStoresDeserializer
    {
        Stores Deserialize();
    }
}
