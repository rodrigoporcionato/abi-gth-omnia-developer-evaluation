using Ambev.DeveloperEvaluation.Application.Sale.GetSale;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;

/// <summary>
/// Profile for mapping GetUser feature requests to commands
/// </summary>
public class GetSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for sale feature
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<int, Application.Sale.GetSale.GetSaleCommand>()
            .ConstructUsing(id => new Application.Sale.GetSale.GetSaleCommand(id));

        CreateMap<GetSaleResult, GetSaleResponse>();
    }
}
