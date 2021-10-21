using AutoMapper;
using DefinexService.BL.Dto.Responses;
using DefinexService.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Basket, BasketResponse>()
            .ForMember(
                dest => dest.BasketItems,
                opt => opt.MapFrom(src => src.BasketItems)
            );

            CreateMap<BasketItems, BasketItemResponse>();
            CreateMap<Product, ProductResponse>()
                .ForMember(
                dest => dest.Category,
                opt => opt.MapFrom(src => src.Category));
        }
    }
}
