using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

/// <summary>
/// Sale item validator class responsible for validating the sale item.
/// </summary>
public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be at least 1.")
            .LessThanOrEqualTo(20).WithMessage("Cannot sell more than 20 identical items.");
    }
}