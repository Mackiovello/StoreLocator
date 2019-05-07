using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreLocator.Dto;
using StoreLocator.Model.Database;

namespace StoreLocator.Repositories
{
    internal class StoreRepository : IStoreRepository
    {
        private readonly StoreContext _storeContext;

        public StoreRepository(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        public async Task<IEnumerable<StoreDto>> GetAllAsync()
        {
            var stores = await _storeContext.Stores.ToArrayAsync();
            return stores.Select(s => new StoreDto(s.Id, s.Name, s.Latitude, s.Longitude));
        }

        public async Task<StoreDto> GetByIdAsync(int id)
        {
            var store = await _storeContext.Stores.SingleOrDefaultAsync(s => s.Id == id);

            if (store == null)
            {
                return null;
            }

            return new StoreDto(store.Id, store.Name, store.Latitude, store.Longitude);
        }
    }
}
