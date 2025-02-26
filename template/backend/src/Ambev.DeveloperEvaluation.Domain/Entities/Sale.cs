
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Sale class responsible for handling the sale
/// </summary>
public class Sale : BaseEntity
{
    public int SaleNumber { get; set; }
    public DateTime Date { get; set; }

    public Guid CustomerId { get; set; } 
    public User Customer { get; set; }
    public string Branch { get; set; }

    public Guid SaleId { get; set; }
    public List<SaleItem> Items { get; set; } = new();
    public decimal TotalAmount { get; set; }
    public bool IsCancelled { get; set; }



    /// <summary>
    /// Calucate the total amount of the sale
    /// Apply discount based on quantity
    /// Discount is applied based on the quantity of the item.
    /// If the quantity is between 4 and 9, the discount is 10%.
    /// If the quantity is between 10 and 20, the discount is 20%.
    /// If the quantity is greater than 20, the discount is 30%.
    /// If the quantity is less than 4, no discount is applied.
    /// </summary>
    public void CalculateTotal()
    {
        TotalAmount = Items.Sum(item =>
        {
            if (item.Quantity > 20)//It's not possible to sell above 20 identical items
            {
                throw new InvalidOperationException("Cannot sell more than 20 identical items.");
            }
            if (item.Quantity >= 10)
            {
                item.Discount = 0.20m; // 20% discount//Purchases between 10 and 20 identical items have a 20% discount
            }
            else if (item.Quantity >= 4)
            {
                item.Discount = 0.10m; // 10% discount//Purchases above 4 identical items have a 10% discount
            }
            else
            {
                // No discounts allowed for quantities below 4 items
                item.Discount = 0m; // No discount
            }

            item.Total = item.Quantity * item.Product.Price * (1 - item.Discount);

            return item.Total;
        });

    }

}