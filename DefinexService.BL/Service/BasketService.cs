using DefinexService.BL.Dto.Requests;
using DefinexService.BL.Dto.Responses;
using DefinexService.BL.Interfaces;
using DefinexService.DAL.Entity;
using DefinexService.DAL.UOW;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using System;
using System.Collections.Generic;

namespace DefinexService.BL.Service
{
    public class BasketService : IBasketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BasketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BasketResponse> AddItemToBasket(BasketRequest request)
        {
            var basketRepository = _unitOfWork.GetRepository<Basket>();
            var basketItemRepository = _unitOfWork.GetRepository<BasketItems>();
            var productRepository = _unitOfWork.GetRepository<Product>();

            try
            {
                var currentBasket = await basketRepository.FindBy(x => x.Id == request.Id).FirstOrDefaultAsync();
                var product = await productRepository.FindBy(x => x.Id == request.BasketItem.Id).FirstOrDefaultAsync();

                if (currentBasket == null)
                {
                    var basket = new Basket
                    {
                        Guid = Guid.NewGuid().ToString()
                    };

                    currentBasket = await basketRepository.AddAsync(basket);
                    await _unitOfWork.SaveChangesAsync();
                }

                var basketItemEntity = new BasketItems
                {
                    ProductId = product.Id,
                    Quantity = request.BasketItem.Quantity,
                    Name = product.Name,
                    Price = product.Price,
                    BasketId = currentBasket.Id
                };


                await basketItemRepository.AddAsync(basketItemEntity);
                await _unitOfWork.SaveChangesAsync();

                var returnModel = await GetBasketWithItems(currentBasket.Id);

                return returnModel;
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            var productRepository = _unitOfWork.GetRepository<Product>();

            var products = await productRepository.GetAll(x => x.Category).ToListAsync();

            var productResponse = _mapper.Map<List<ProductResponse>>(products);

            return productResponse;
        }

        public async Task<BasketResponse> GetBasket(long id)
        {
            var basketRepository = _unitOfWork.GetRepository<Basket>();

            var currentBasket = await basketRepository.FindBy(x => x.Id == id, y => y.BasketItems).FirstOrDefaultAsync();

            var basketResponse = _mapper.Map<BasketResponse>(currentBasket);

            return basketResponse;
        }

        private async Task<BasketResponse> GetBasketWithItems(long basketId)
        {
            var basketRepository = _unitOfWork.GetRepository<Basket>();

            var basket = await basketRepository.FindBy(b => b.Id == basketId)
                .Include(b => b.BasketItems).FirstOrDefaultAsync();

            return _mapper.Map<BasketResponse>(basket);
        }
    }
}
