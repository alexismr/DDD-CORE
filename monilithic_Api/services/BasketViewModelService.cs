
/// <summary>
///  servicios que solo son consumidos desde el front  por eso no se encuentran en la capa de dominio ya que no tiene logica de negociio 
/// </summary>

namespace monilithic_Api.services
{
    using ApplicationCore.Entities;
    using ApplicationCore.Entities.BasketAggregate;
    using ApplicationCore.Interfaces;
    using ApplicationCore.Specifications;
    using monilithic_Api.interfaces;
    using monilithic_Api.ViewModels.basketViewModel;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;



    public class BasketViewModelService : IBasketViewModelService
    {
        private readonly IAsyncRepository<Basket> _basketRepository;
        private readonly IUriComposer _uriComposer;
        private readonly IRepository<CatalogItem> _itemRepository;
        private readonly IAsyncRepository<BasketItem> _basketItemRepository;

        public BasketViewModelService(IAsyncRepository<Basket> basketRepository,
            IRepository<CatalogItem> itemRepository,
            IUriComposer uriComposer,
            IAsyncRepository<BasketItem> basketItemRepository )
        {
            _basketRepository = basketRepository;
            _uriComposer = uriComposer;
            _itemRepository = itemRepository;
            _basketItemRepository = basketItemRepository;
        }

        public async Task<BasketViewModel> GetOrCreateBasketForUser(string userName)
        {
            var basketSpec = new BasketWithItemsSpecification(userName);
            var basket = (await _basketRepository.ListAsync(basketSpec)).FirstOrDefault();

            if (basket == null)
            {
                return await CreateBasketForUser(userName);
            }
            return CreateViewModelFromBasket(basket);
        }

        private BasketViewModel CreateViewModelFromBasket(Basket basket)
        {
            var viewModel = new BasketViewModel();
            viewModel.Id = basket.Id;
            viewModel.BuyerId = basket.BuyerId;
            viewModel.Items = basket.Items.Select(i =>
            {
                var itemModel = new BasketItemViewModel()
                {
                    Id = i.Id,
                    UnitPrice = i.UnitPrice,
                    Quantity = i.Quantity,
                    CatalogItemId = i.CatalogItemId

                };
                var item = _itemRepository.GetById(i.CatalogItemId);
                itemModel.PictureUrl = _uriComposer.ComposePicUri(item.PictureUri);
                itemModel.ProductName = item.Name;
                return itemModel;
            })
                            .ToList();
            return viewModel;
        }

        private async Task<BasketViewModel> CreateBasketForUser(string userId)
        {
            var basket = new Basket() { BuyerId = userId };
            await _basketRepository.AddAsync(basket);

            return new BasketViewModel()
            {
                BuyerId = basket.BuyerId,
                Id = basket.Id,
                Items = new List<BasketItemViewModel>()
            };
        }


    }
}
