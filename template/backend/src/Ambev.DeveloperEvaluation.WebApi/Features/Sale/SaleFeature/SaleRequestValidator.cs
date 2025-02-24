using Ambev.DeveloperEvaluation.WebApi.Features.Sale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.SaleFeature;

/// <summary>
/// Validator for AuthenticateUserRequest
/// </summary>
public class SaleRequestValidator : AbstractValidator<SaleRequest>
{
    /// <summary>
    /// Initializes validation rules for AuthenticateUserRequest
    /// </summary>
    public SaleRequestValidator()
    {
           RuleFor(x => x.Items).NotEmpty().WithMessage("Items cannot be empty");

        RuleForEach(x => x.Items).ChildRules(item => 
        {
            item.RuleFor(x => x.ProductId)
                .GreaterThan(0)
                .WithMessage("ProductId must be greater than 0");

            item.RuleFor(x => x.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity must be greater than 0")
                .LessThanOrEqualTo(20)
                .WithMessage("Cannot sell more than 20 identical items");
        });
        

    }
}
