using Microsoft.Extensions.Caching.Memory;
using StoreLocator.Model.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreLocator.Repositories
{
    internal class StoreRepositoryFactory : IStoreRepositoryFactory
    {
        private readonly IMemoryCache _cache;
        private readonly StoreContext _storeContext;

        public StoreRepositoryFactory(IMemoryCache cache, StoreContext storeContext)
        {
            _cache = cache;
            _storeContext = storeContext;
        }

        public IStoreRepository Create()
        {
            var storeRepository = new StoreRepository(_storeContext);
            return new CachedStoreRepository(_cache, storeRepository);
        }
    }
}
