
using ApplicationCore.Entities.BasketAggregate;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UnitTests.Builders;
using Xunit;
using Xunit.Abstractions;

namespace IntegrationTests.Repositories.BasketItemRepositoryTests
{
    public class DeleteAsync_Should
    {
        private readonly CatalogContext _catalogContext;
        private readonly EfRepository<Basket> _basketRepository;
        private readonly EfRepository<BasketItem> _basketItemRepository;
        private BasketBuilder BasketBuilder { get; } = new BasketBuilder();
        private readonly ITestOutputHelper _output;

        public DeleteAsync_Should(ITestOutputHelper output)
        {
            _output = output;
            var dbOptions = new DbContextOptionsBuilder<CatalogContext>()
                .UseInMemoryDatabase(databaseName: "TestCatalog")
                .Options;
            _catalogContext = new CatalogContext(dbOptions);
            _basketRepository = new EfRepository<Basket>(_catalogContext);
            _basketItemRepository = new EfRepository<BasketItem>(_catalogContext);
        }

        [Fact]
        public async Task DeleteItemFromBasket()
        {
            var existingBasket = BasketBuilder.WithOneBasketItem();
            _catalogContext.Add(existingBasket);
            _catalogContext.SaveChanges();
            
            await _basketItemRepository.DeleteAsync(existingBasket.Items.FirstOrDefault());
            _catalogContext.SaveChanges();

            var basketFromDB = _basketRepository.GetById(BasketBuilder.BasketId);

            Assert.Equal(0, basketFromDB.Items.Count);
        }
    }
}
