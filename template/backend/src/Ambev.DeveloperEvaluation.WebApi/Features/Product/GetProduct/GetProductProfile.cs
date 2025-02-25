using Ambev.DeveloperEvaluation.Application.Product.GetProduct;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.GetProduct
{
    public class GetProductProfile: Profile
    {

        public GetProductProfile() {

            //CreateMap<Domain.Entities.Product, GetProductResult>()
            // .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            // .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            // .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            // .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            // .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.category))
            // .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

            //CreateMap<List<Domain.Entities.Product>, List<GetProductResult>>();

            CreateMap<GetProductResult, GetProductResponse>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price));


        }

    }
}
