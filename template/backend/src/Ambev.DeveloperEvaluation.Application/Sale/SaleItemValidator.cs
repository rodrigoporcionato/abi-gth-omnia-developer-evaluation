using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(x => x.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be at least 1.")
            .LessThanOrEqualTo(20).WithMessage("Cannot sell more than 20 identical items.");
    }
}