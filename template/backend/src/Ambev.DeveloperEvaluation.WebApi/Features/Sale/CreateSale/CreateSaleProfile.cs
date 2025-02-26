


using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

public class SaleMappingProfile : Profile
{
    public SaleMappingProfile()
    {

        CreateMap<CreateSaleRequest, SaleCommand>()
           .ForMember(dest => dest.Customer, opt => opt.MapFrom(src => src.UserId.ToString())) 
           .ForMember(dest => dest.Branch, opt => opt.Ignore()) 
           .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Products)); 

        CreateMap<SaleProductRequest, SaleItem>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));


        //CreateMap<CreateSaleRequest, SaleCommand>();
        //CreateMap<CreateSaleResponse, CreateSaleResponse>();
    }
}
