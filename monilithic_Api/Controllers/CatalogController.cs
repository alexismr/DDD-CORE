using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using monilithic_Api.interfaces;
using monilithic_Api.ViewModels;

namespace monilithic_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ICatalogService _catalogService;
        public CatalogController(ICatalogService catalogService) => _catalogService = catalogService;

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var catalogModel = await _catalogService.GetCatalogItems();
            return Ok(catalogModel);
        }


        [HttpPost]
        public async Task<IActionResult> SetCatalog(CatalogItemViewModel item)
        {

            return Ok();
        }

    }
}