
namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Sale item class responsible for handling the sale item
/// Discount business rules and quantity limit make more sense in the domain (Saleitem), 
// as they are essential rules of business logic and should be guaranteed 
// regardles of how the request arrives.
/// </summary>
public class SaleItem
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }

    /// <summary>
    /// Apply discount based on quantity
    /// Discount is applied based on the quantity of the item.
    /// If the quantity is between 4 and 9, the discount is 10%.
    /// If the quantity is between 10 and 20, the discount is 20%.
    /// If the quantity is greater than 20, the discount is 30%.
    /// If the quantity is less than 4, no discount is applied.
    /// </summary>
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