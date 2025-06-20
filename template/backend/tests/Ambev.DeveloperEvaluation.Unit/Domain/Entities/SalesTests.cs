using Xunit;
using FluentAssertions;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;


public class SaleTests
{

    private readonly IMapper _mapper;


    public SaleTests()
    {
        var config = new MapperConfiguration(cfg => cfg.AddProfile<SaleProfile>());
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void SaleProfile_Should_Map_Sale_To_SaleResult_Correctly()
    {
        var sale = new Sale
        {
            SaleNumber = 123,
            Date = new DateTime(2024, 02, 26),
           Customer = new User { Email = "email@domain.com" },
            Branch = "Main Branch",
            Items = new List<SaleItem> { new SaleItem { 
                Product = new Product{ Price = 1 }, Quantity = 2} },
            TotalAmount = 100m
        };

        var result = _mapper.Map<SaleResult>(sale);

        // Assert
        result.Should().NotBeNull();
        result.SaleNumber.Should().Be(sale.SaleNumber);
        result.Date.Should().Be(sale.Date);
        result.Customer.Should().Be(sale.Customer.Email);
        result.Branch.Should().Be(sale.Branch);
        result.Items.Should().HaveCount(sale.Items.Count);
        result.TotalAmount.Should().Be(sale.TotalAmount);
    }


    /// <summary>
    /// Test to validate discounts
    /// </summary>
    [Fact]
    public void CalculateTotal_Should_ApplyCorrect_Discount()
    {
        var sale = SaleFaker.Generate().Generate();

        sale.CalculateTotal();

        foreach (var item in sale.Items)
        {
            if (item.Quantity >= 10)
                item.Discount.Should().Be(0.20m);
            else if (item.Quantity >= 4)
                item.Discount.Should().Be(0.10m);
            else
                item.Discount.Should().Be(0m);
        }

        // Validate that the calculated TotalAmount matches the sum of item totals
        sale.TotalAmount.Should().Be(sale.Items.Sum(i => i.Total));
    }

    /// <summary>
    /// shoould throw error when quantity exceed the limit of product by the rule,(max 20)
    /// </summary>
    [Fact]
    public void CalculateTotal_ShouldThrowException_When_Quantity_Exceeds_Limit()
    {
        
        var sale = SaleFaker.Generate().Generate();
        sale.Items.First().Quantity = 21; //it invalidate rule because have more than 20 quantities

        Action action = () => sale.CalculateTotal();
        action.Should().Throw<InvalidOperationException>()
            .WithMessage("Cannot sell more than 20 identical items.");
    }
}
