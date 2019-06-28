
using ApplicationCore.Services;
using System;
using Xunit;

namespace UnitTests.ApplicationCore.Services.CatalogServiceTests
{
    public class TransferCatalog
    {

        [Fact]
        public async void TestOrderService()
        {
            var orderService = new OrderService(null, null, null);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await orderService.CreateOrderAsync(1, null));
        }

    }
}
