using StoreLocator.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            // TODO: Add stores from XML file
            _storesContext.Stores.Add(new Store() { Id = "som", Latitude = "123", Longitude = "1231", Name = "mystore" });

            _storesContext.SaveChanges();
        }
    }
}
