using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.DeleteSale;

/// <summary>
/// Validator for sale command
/// </summary>
public class DeleteSaleValidator : AbstractValidator<DeleteSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for sale command
    /// </summary>
    public DeleteSaleValidator()
    {
        RuleFor(x => x.SaleNumber)
            .NotEmpty()
            .WithMessage("sale ID is required");
    }
}
