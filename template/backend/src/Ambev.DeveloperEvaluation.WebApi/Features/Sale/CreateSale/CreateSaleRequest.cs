using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.ProductFeature;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

public class CreateSaleRequest
{
    public Guid UserId { get; set; }

    public List<SaleProductRequest> Products { get; set; }
}

public class SaleProductRequest
{

    public Guid ProductId { get; set; }
    public int Quantity { get; set; }
}

