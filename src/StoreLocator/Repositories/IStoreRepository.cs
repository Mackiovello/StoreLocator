using StoreLocator.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreLocator.Repositories
{
    public interface IStoreRepository
    {
        Task<StoreDto> GetByIdAsync(int id);
        Task<IEnumerable<StoreDto>> GetAllAsync();
    }
}
