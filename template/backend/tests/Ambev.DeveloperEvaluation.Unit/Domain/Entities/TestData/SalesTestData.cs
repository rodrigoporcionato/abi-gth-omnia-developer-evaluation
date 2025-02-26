using Bogus;
using Ambev.DeveloperEvaluation.Domain.Entities;


namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;


public static class SaleFaker
{
    public static Faker<Sale> Generate()
    {
        return new Faker<Sale>()
            .RuleFor(s => s.SaleNumber, f => f.Random.Int(1000, 9999))
            .RuleFor(s => s.Date, f => f.Date.Past(1))
            .RuleFor(s => s.CustomerId, f => Guid.NewGuid())
            .RuleFor(s => s.Branch, f => f.Company.CompanyName())
            .RuleFor(s => s.SaleId, f => Guid.NewGuid())
            .RuleFor(s => s.Items, f => SaleItemFaker.Generate().Generate(f.Random.Int(1, 5)))
            .RuleFor(s => s.TotalAmount, 0) // Calculado na chamada do método CalculateTotal()
            .RuleFor(s => s.IsCancelled, f => f.Random.Bool());
    }
}

public static class SaleItemFaker
{
    public static Faker<SaleItem> Generate()
    {
        return new Faker<SaleItem>()
            .RuleFor(i => i.Quantity, f => f.Random.Int(1, 20))
            .RuleFor(i => i.Product, f => new Product { Price = f.Random.Decimal(10, 500) }) // Produto fake
            .RuleFor(i => i.Total, 0) // Calculado na chamada de CalculateTotal()
            .RuleFor(i => i.Discount, 0);
    }
}
