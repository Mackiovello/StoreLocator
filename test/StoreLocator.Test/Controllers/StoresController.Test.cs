using Microsoft.AspNetCore.Mvc;
using Moq;
using StoreLocator.Controllers;
using StoreLocator.Dto;
using StoreLocator.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StoreLocator.Test.Controllers
{
    public class StoresControllerTests
    {
        [Fact]
        public async void NonExistentId_ReturnsNotFoundResult()
        {
            int id = 3;
            var storeService = Mock.Of<IStoreService>(
                s => s.GetByIdAsync(id) == Task.FromResult<StoreDto>(null));
            var controller = new StoresController(storeService);

            var result = await controller.GetAsync(id);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async void ExistingId_ReturnsDto()
        {
            // This test is pretty bad, it only tests
            // that the controller returns the store
            // that the service returns.
            var id = 3;
            var store = new StoreDto(id, "HugeStore", "123.132", "42.42");
            var storeService = Mock.Of<IStoreService>(
                s => s.GetByIdAsync(id) == Task.FromResult(store));
            var controller = new StoresController(storeService);

            var result = await controller.GetAsync(id);

            Assert.Equal(store, result.Value);
        }

        [Fact]
        public async void ReturnsAllFromService()
        {
            IEnumerable<StoreDto> stores = new[]
            {
                new StoreDto(42, "HugeStore", "123.123", "42.42"),
                new StoreDto(43, "TinyStore", "123.123", "42.42"),
            };
            var storeService = Mock.Of<IStoreService>(
                s => s.GetAllAsync() == Task.FromResult(stores));
            var controller = new StoresController(storeService);

            var result = await controller.GetAsync();

            Assert.Equal(stores, result.Value);
        }
    }
}
