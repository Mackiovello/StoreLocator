using StoreLocator.Model.Database;
using System.Linq;

namespace StoreLocator.Data
{
    internal class DatabaseSeeder : IDatabaseSeeder
    {
        private readonly IStoresDeserializer _storesDeserializer;
        private readonly StoreContext _storeContext;

        public DatabaseSeeder(
            IStoresDeserializer storesDeserializer,
            StoreContext storeContext)
        {
            _storesDeserializer = storesDeserializer;
            _storeContext = storeContext;
        }

        public void Seed()
        {
            _storeContext.Database.EnsureCreated();

            if (_storeContext.Stores.Any())
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

                _storeContext.Stores.Add(databaseStore);
            }

            _storeContext.SaveChanges();
        }
    }
}
