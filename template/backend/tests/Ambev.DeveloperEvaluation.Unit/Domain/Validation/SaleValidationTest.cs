using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

/// <summary>
/// Scenatio validation with all posibilities based on rules request by interview
/// </summary>
public class SaleTests
{
    [Fact(DisplayName = "Scenatio validation with all posibilities")]
    public void CalculateTotal_Should_Correctly_Calculate_TotalAmount()
    {
        //simulate all values with or without disconts
        var sale = new Sale
        {
            Items = new List<SaleItem>
            {
                new SaleItem { Product = new Product { Price = 7.95m }, Quantity = 12 }, // 20% of discount
                new SaleItem { Product = new Product { Price = 109m }, Quantity = 1 },  // no discont
                new SaleItem { Product = new Product { Price = 7.95m }, Quantity = 0 },  // Zero itens
               new SaleItem { Product = new Product { Price = 29.95m }, Quantity = 15 } // 20% discount
            }
        };
                
        sale.CalculateTotal();

        // Assert
        decimal expectedTotal = (12 * 7.95m * 0.8m) + (1 * 109m) + (0 * 7.95m) + (15 * 29.95m * 0.8m);
        
        Assert.Equal(expectedTotal, sale.TotalAmount, 2); // allowds precision of 2

    }
}

