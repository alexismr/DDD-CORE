using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using monilithic_Api.interfaces;
using monilithic_Api.ViewModels;
using monilithic_Api.ViewModels.basketViewModel;

namespace monilithic_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {

        private readonly IBasketService _basketService;
        private readonly IBasketViewModelService _basketViewModelService;

        public BasketController(IBasketService basketService , IBasketViewModelService basketViewModelService)
        {
            _basketService = basketService;
            _basketViewModelService = basketViewModelService;
        }


        public BasketViewModel BasketModel { get; set; } = new BasketViewModel();

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var catalogModel = await _basketService.GetCatalogItems();
            return Ok(catalogModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddtemToBasket(CatalogItemViewModel productDetails)
        {

            await _basketService.AddItemToBasket(BasketModel.Id, productDetails.Id, productDetails.Price, 1);
            var  BasketModelS = await _basketViewModelService.GetOrCreateBasketForUser("alexis");
            return Ok(BasketModelS);
        }



        [HttpDelete]
        public async Task DeleteBasketAsync(int basketId)
        {
            await _basketService.DeleteBasketAsync(basketId);
        }



    }
}