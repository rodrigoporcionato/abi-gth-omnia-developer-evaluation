using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;

/// <summary>
/// API response model for GetUser operation
/// </summary>
public class GetSaleResponse
{

    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public string Customer { get; set; }
    public string Branch { get; set; }
    public List<SaleItem> Items { get; set; } = new List<SaleItem>();
    public decimal TotalAmount { get; set; }


}
