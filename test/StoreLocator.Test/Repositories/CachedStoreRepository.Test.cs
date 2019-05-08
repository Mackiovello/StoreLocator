using Microsoft.Extensions.Caching.Memory;
using Moq;
using StoreLocator.Repositories;
using Xunit;

namespace StoreLocator.Test.Repositories
{
    public class CachedStoreRepositoryTests
    {
        [Fact]
        public async void RetrievingAllTwiceInARow_CallsRepositoryOnce()
        {
            var repository = new Mock<IStoreRepository>();
            var cache = new MemoryCache(new MemoryCacheOptions()); 
            var cachedRepository = new CachedStoreRepository(cache, repository.Object);

            var result1 = await cachedRepository.GetAllAsync();
            var result2 = await cachedRepository.GetAllAsync();

            repository.Verify(s => s.GetAllAsync(), Times.Once());
            Assert.Equal(result1, result2);
        }

        [Fact]
        public async void InvalidatingCacheBetweenTwoCalls_CallsRepositoryTwice()
        {
            var repository = new Mock<IStoreRepository>();
            var cache = new MemoryCache(new MemoryCacheOptions());
            var cachedRepository = new CachedStoreRepository(cache, repository.Object);

            var result1 = await cachedRepository.GetAllAsync();
            cache.Remove(CacheKeys.AllStores);
            var result2 = await cachedRepository.GetAllAsync();

            repository.Verify(s => s.GetAllAsync(), Times.Exactly(2));
            Assert.Equal(result1, result2);
        }
    }
}
