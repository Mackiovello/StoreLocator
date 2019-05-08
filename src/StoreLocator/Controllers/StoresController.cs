using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreLocator.Dto;
using StoreLocator.Services;

namespace StoreLocator.Controllers
{
    [Route("location/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoresController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        public async Task<ActionResult<StoreDto[]>> GetAsync()
        {
            var stores = await _storeService.GetAllAsync();
            // No implicit casts to interfaces, so we have
            // to use an array instead of IEnumerable
            return stores.ToArray();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StoreDto>> GetAsync(int id)
        {
            var store = await _storeService.GetByIdAsync(id);

            if (store == null)
            {
                return new NotFoundResult();
            }

            return store;
        }
    }
}
