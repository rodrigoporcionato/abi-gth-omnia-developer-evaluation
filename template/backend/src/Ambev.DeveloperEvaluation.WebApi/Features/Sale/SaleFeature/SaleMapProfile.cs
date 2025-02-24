

using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.SaleFeature;
using Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleMappingProfile : Profile
{
    public SaleMappingProfile()
    {          

           CreateMap<ProductRequest, Product>()
            .ForMember(dest => dest.Image, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.Rating, opt => opt.Ignore());

        CreateMap<ProductRequest, SaleItem>();  // Add this mapping

        CreateMap<SaleRequest, SaleItem>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Items));

        CreateMap<SaleRequest, SaleCommand>()
            .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));


    }
}
