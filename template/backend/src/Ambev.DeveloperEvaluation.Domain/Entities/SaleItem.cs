
using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Sale item class responsible for handling the sale item
/// Discount business rules and quantity limit make more sense in the domain (Saleitem), 
// as they are essential rules of business logic and should be guaranteed 
// regardles of how the request arrives.
/// </summary>
public class SaleItem : BaseEntity
{

    public Guid SaleId { get; set; }


    public Product Product { get; set; }

    public Guid ProductId { get; set; }


    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal Total { get; set; }
 
}