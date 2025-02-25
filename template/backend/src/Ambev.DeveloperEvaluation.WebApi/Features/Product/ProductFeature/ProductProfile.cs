using Ambev.DeveloperEvaluation.Application.Product.CreateProduct;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.ProductFeature
{
    public class ProductProfile : Profile
    {

        public ProductProfile()
        {

            CreateMap<CreateProductResult, ProductResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));



            CreateMap<ProductRequest, CreateProductCommand>()
               .ForMember(dest => dest.RatingCount, opt => opt.MapFrom(src => src.Rating.Count)) 
               .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Rating.Rate));


            CreateMap<ProductResponse, CreateProductResult>();



        }


    }
}
