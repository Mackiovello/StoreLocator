using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using StoreLocator.Dto;

namespace StoreLocator.Repositories
{
    // This is some insane overengineering,
    // but it's fun :) 
    internal class CachedStoreRepository : IStoreRepository
    {
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(5);
        private readonly IMemoryCache _cache;
        private readonly IStoreRepository _storeRepository;

        public CachedStoreRepository(IMemoryCache cache, IStoreRepository storeRepository)
        {
            _cache = cache;
            _storeRepository = storeRepository;
        }

        public async Task<IEnumerable<StoreDto>> GetAllAsync()
        {
            return await _cache.GetOrCreateAsync(CacheKeys.AllStores, entry =>
            {
                entry.SlidingExpiration = _cacheExpiration;
                return _storeRepository.GetAllAsync();
            });
        }

        public async Task<StoreDto> GetByIdAsync(int id)
        {
            // We could cache the individual results but 
            // the benefit would be limited. The biggest 
            // performance benefit for this method would 
            // probably be if we stored all the stores in 
            // a dictionary so we'd get O(1) retrieval.
            return (await GetAllAsync()).SingleOrDefault(s => s.Id == id);
        }
    }
}
