using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.DeleteSale;

/// <summary>
/// Validator for DeletesalerRequest
/// </summary>
public class DeleteSaleRequestValidator : AbstractValidator<DeleteSaleRequest>
{
    /// <summary>
    /// Initializes validation rules for del sales
    /// </summary>
    public DeleteSaleRequestValidator()
    {
        RuleFor(x => x.SaleNumber)
            .NotEmpty()
            .WithMessage("SaleNumber is required");
    }
}
