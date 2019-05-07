using StoreLocator.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StoreLocator.Services
{
    public interface IStoreService
    {
        Task<StoreDto> GetByIdAsync(int id);
        Task<IEnumerable<StoreDto>> GetAllAsync();
    }
}
