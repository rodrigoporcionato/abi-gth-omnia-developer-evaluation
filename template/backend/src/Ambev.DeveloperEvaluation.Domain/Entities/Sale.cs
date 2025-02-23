
namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Sale class responsible for handling the sale
/// </summary>
public class Sale
{
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }
    public User Customer { get; set; }
    public string Branch { get; set; }
    public List<SaleItem> Items { get; set; } = new();
    public decimal TotalAmount { get; set; }
    public bool IsCancelled { get; set; }

    public void CalculateTotal()
    {
        TotalAmount = 0;
        foreach (var item in Items)
        {
            item.ApplyDiscount();
            TotalAmount += item.Total;
        }
    }
}