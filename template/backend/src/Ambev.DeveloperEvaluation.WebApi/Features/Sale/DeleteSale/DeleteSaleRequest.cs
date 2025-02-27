namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.DeleteSale;

/// <summary>
/// Request model for deleting sale
/// </summary>
public class DeleteSaleRequest
{
    /// <summary>
    /// The unique identifier of the sale to delete
    /// </summary>
    public int SaleNumber { get; set; }
}
