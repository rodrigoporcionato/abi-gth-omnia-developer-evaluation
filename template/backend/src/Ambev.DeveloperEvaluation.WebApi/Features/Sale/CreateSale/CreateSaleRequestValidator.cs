using Ambev.DeveloperEvaluation.WebApi.Features.Sale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;

/// <summary>
/// Validator for AuthenticateUserRequest
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes validation rules for AuthenticateUserRequest
    /// </summary>
    public CreateSaleRequestValidator()
    {
           RuleFor(x => x.Products).NotEmpty().WithMessage("Items cannot be empty");

        //RuleForEach(x => x.Products).ChildRules(item =>
        //{
        //    item.RuleFor(x => x.Price)
        //        .GreaterThan(0)
        //        .WithMessage("ProductId must be greater than 0");

        //    item.RuleFor(x => x.)
        //        .GreaterThan(0)
        //        .WithMessage("Quantity must be greater than 0")
        //        .LessThanOrEqualTo(20)
        //        .WithMessage("Cannot sell more than 20 identical items");
        //});


    }
}
