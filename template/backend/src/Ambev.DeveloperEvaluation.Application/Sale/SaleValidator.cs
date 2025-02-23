


using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

public class SaleValidator : AbstractValidator<SaleCommand>
    {
        public SaleValidator()
        {
            RuleFor(x => x.Customer).NotEmpty();
            RuleFor(x => x.Branch).NotEmpty();
            RuleForEach(x => x.Items).SetValidator(new SaleItemValidator());
        }
    }