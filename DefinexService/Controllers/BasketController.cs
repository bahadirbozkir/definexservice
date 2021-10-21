using DefinexService.BL.Dto.Requests;
using DefinexService.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefinexService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [HttpPost("add-item")]
        public async Task<IActionResult> AddItem([FromBody] BasketRequest request)
        {
            var result = await _basketService.AddItemToBasket(request);

            return Ok(result);
        }

        [HttpGet("get-all")]
        public async Task<IActionResult> GetItems()
        {
            var result = await _basketService.GetAllProducts();

            return Ok(result);
        }

        [HttpGet("get-basket/{id}")]
        public async Task<IActionResult> GetBasket(long id)
        {
            var result = await _basketService.GetBasket(id);

            return Ok(result);
        }
    }
}
