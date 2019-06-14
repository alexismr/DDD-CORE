using monilithic_Api.services;
using System;
using Xunit;

namespace UnitTests.ApplicationCore.Services.CatalogServiceTests
{
    public class TransferCatalog
    {

        [Fact]
        public async void ThrowsGivenNullAnonymousId()
        {
            var basketService = new CatalogService(null, null, null, null, null);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await basketService.TransferBasketAsync(null, "steve"));
        }

        [Fact]
        public async void ThrowsGivenNullUserId()
        {
            var basketService = new CatalogService(null, null, null, null, null);
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await basketService.TransferBasketAsync("abcdefg", null));
        }

    }
}
