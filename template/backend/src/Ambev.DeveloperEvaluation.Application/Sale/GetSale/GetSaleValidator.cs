using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;

/// <summary>
/// Validator for salecmd
/// </summary>
public class GetSaleValidator : AbstractValidator<GetSaleCommand>
{
    /// <summary>
    /// Initializes validation rules for salecmd
    /// 
    /// </summary>
    public GetSaleValidator()
    {
        RuleFor(x => x.SaleId)
            .NotEmpty()
            .WithMessage("Sale ID is required");
    }
}
