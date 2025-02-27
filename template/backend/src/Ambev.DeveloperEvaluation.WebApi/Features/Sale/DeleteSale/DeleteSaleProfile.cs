using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.DeleteSale;

/// <summary>
/// Profile for mapping DeleteUser feature requests to commands
/// </summary>
public class DeleteSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for del sales feature
    /// </summary>
    public DeleteSaleProfile()
    {
        CreateMap<int, Application.Sale.DeleteSale.DeleteSaleCommand>()
            .ConstructUsing(id => new Application.Sale.DeleteSale.DeleteSaleCommand(id));
    }
}