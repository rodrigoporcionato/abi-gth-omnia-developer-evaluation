using AutoMapper;
namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;
/// <summary>
/// Profile for mapping between User entity and GetUserResponse
/// </summary>
public class GetSaleProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for sale operation
    /// </summary>
    public GetSaleProfile()
    {
        CreateMap<Domain.Entities.Sale, GetSaleResult>();
    }
}
