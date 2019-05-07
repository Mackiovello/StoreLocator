using StoreLocator.Model.Database;
using System.Linq;

namespace StoreLocator.Data
{
    public class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly IStoresDeserializer _storesDeserializer;
        private readonly StoresContext _storesContext;

        public DatabaseSeeder(
            IStoresDeserializer storesDeserializer,
            StoresContext storesContext)
        {
            _storesDeserializer = storesDeserializer;
            _storesContext = storesContext;
        }

        public void Seed()
        {
            _storesContext.Database.EnsureCreated();

            if (_storesContext.Stores.Any())
            {
                return;
            }

            var stores = _storesDeserializer.Deserialize();

            foreach (var store in stores.AllStores)
            {
                var databaseStore = new Store()
                {
                    Id = store.Id,
                    Name = store.Name,
                    Longitude = store.Longitude,
                    Latitude = store.Latitude
                };

                _storesContext.Stores.Add(databaseStore);
            }

            _storesContext.SaveChanges();
        }
    }
}
