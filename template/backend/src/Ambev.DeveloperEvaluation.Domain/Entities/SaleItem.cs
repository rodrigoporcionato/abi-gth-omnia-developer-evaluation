
namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleItem
{
    public string Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }

    public void ApplyDiscount()
    {
        if (Quantity >= 4 && Quantity < 10)
            Discount = 0.10m;
        else if (Quantity >= 10 && Quantity <= 20)
            Discount = 0.20m;
        else
            Discount = 0;

        Total = Quantity * UnitPrice * (1 - Discount);
    }
}