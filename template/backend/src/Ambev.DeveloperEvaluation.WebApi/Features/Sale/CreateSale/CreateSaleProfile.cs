


using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

public class SaleMappingProfile : Profile
{
    public SaleMappingProfile()
    {
        CreateMap<CreateSaleRequest, SaleCommand>();
        CreateMap<CreateSaleResponse, CreateSaleResponse>();
    }
}
