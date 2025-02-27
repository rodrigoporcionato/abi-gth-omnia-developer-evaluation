namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;

/// <summary>
/// request for get sales by id
/// </summary>
public class GetSaleRequest
{
    /// <summary>
    /// The unique identifier of the sale to retrieve
    /// </summary>
    public int SaleNumber { get; set; }

}
