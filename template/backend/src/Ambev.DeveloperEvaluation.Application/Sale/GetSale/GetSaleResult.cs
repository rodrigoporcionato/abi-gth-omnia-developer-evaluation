using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;

/// <summary>
/// Response model for sale operation
/// </summary>
public class GetSaleResult
{
    /// <summary>
    /// The unique identifier of the sale
    /// </summary>
    public Guid Id { get; set; }

    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public string Customer { get; set; }
    public string Branch { get; set; }
    public List<SaleItem> Items { get; set; } = new List<SaleItem>();
    public decimal TotalAmount { get; set; }
}
