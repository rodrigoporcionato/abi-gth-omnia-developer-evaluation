using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Features.Product.ProductFeature;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

/// <summary>
/// responsible payload the sell items
/// </summary>
public class CreateSaleRequest
{
    public required Guid UserId { get; set; }

    public required string Branch { get; set; }

    public required List<SaleProductRequest> Products { get; set; }
}

