using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace monilithic_Api.interfaces
{
    public interface IBasketService
    {
        Task<IActionResult> GetCatalogItems();
        Task AddItemToBasket(int basketId, int catalogItemId, decimal price, int quantity);
        Task<int> GetBasketItemCountAsync(string userName);
        Task DeleteBasketAsync(int basketId);
    }
}
