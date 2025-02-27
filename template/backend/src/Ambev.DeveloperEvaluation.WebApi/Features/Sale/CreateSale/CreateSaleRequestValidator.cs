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


    }
}
