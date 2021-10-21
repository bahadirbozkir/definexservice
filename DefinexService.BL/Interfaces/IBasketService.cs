using DefinexService.BL.Dto.Requests;
using DefinexService.BL.Dto.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DefinexService.BL.Interfaces
{
    public interface IBasketService
    {
        Task<BasketResponse> AddItemToBasket(BasketRequest request);

        Task<BasketResponse> GetBasket(long id);
        Task<List<ProductResponse>> GetAllProducts();
    }
}
