
using ApplicationCore.Interfaces;
using ApplicationCore.Entities.BasketAggregate;
using ApplicationCore.Services;
using ApplicationCore.Exceptions;
namespace UnitTests.ApplicationCore.Services.BasketServiceTests
{
    using System;
    using Xunit;
    using Moq;
 
    // usar moq para simular el consumo del servicio 
    public class SetQuantities
    {
        private int _invalidId = -1;
        private Mock<IAsyncRepository<Basket>> _mockBasketRepo;

        public SetQuantities()
        {
            _mockBasketRepo = new Mock<IAsyncRepository<Basket>>();
        }

        [Fact]
        public async void ThrowsGivenInvalidBasketId()
        {
            var basketService = new BasketService(_mockBasketRepo.Object, null, null, null, null);

            await Assert.ThrowsAsync<BasketNotFoundException>(async () =>
                await basketService.SetQuantities(_invalidId, new System.Collections.Generic.Dictionary<string, int>()));
        }

        [Fact]
        public async void ThrowsGivenNullQuantities()
        {
            var basketService = new BasketService(null, null, null, null, null);

            await Assert.ThrowsAsync<ArgumentNullException>(async () =>
                await basketService.SetQuantities(123, null));
        }

    }
}
