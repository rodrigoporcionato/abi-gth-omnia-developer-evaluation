namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

public class SaleProductRequest
{
    public required Guid ProductId { get; set; }
    public required int Quantity { get; set; }
}

