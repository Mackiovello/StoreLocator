using System.Collections.Generic;
using System.Threading.Tasks;
using StoreLocator.Dto;
using StoreLocator.Repositories;

namespace StoreLocator.Services
{
    internal class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task<IEnumerable<StoreDto>> GetAllAsync()
        {
            return await _storeRepository.GetAllAsync();
        }

        public async Task<StoreDto> GetByIdAsync(int id)
        {
            return await _storeRepository.GetByIdAsync(id);
        }
    }
}
