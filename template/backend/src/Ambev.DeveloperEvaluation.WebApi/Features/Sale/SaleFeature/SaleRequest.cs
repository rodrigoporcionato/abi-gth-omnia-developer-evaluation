using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.SaleFeature;

public class SaleRequest
{
    public List<ProductRequest> Items { get; set; } = new();
}

public class ProductRequest 
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }

}