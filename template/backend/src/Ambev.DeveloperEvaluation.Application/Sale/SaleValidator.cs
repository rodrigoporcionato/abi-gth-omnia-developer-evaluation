


using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;

public class SaleValidator : AbstractValidator<SaleCommand>, ISaleValidator
{
    public SaleValidator()
    {
        RuleFor(x => x.Customer).NotEmpty();
        RuleFor(x => x.Branch).NotEmpty();
        RuleForEach(x => x.Items).SetValidator(new SaleItemValidator());
    }

    public async Task ValidateAndThrowAsync(SaleCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await this.ValidateAsync(command, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
    }

}

public interface ISaleValidator
{
    Task ValidateAndThrowAsync(SaleCommand command, CancellationToken cancellationToken);
}


