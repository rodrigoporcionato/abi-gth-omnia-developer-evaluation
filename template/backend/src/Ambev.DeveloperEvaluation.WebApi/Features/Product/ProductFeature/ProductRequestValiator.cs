using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.ProductFeature
{
    public class ProductRequestValiator : AbstractValidator<ProductRequest>
    {
        public ProductRequestValiator()
        {
            RuleFor(product => product.Title).NotEmpty().MaximumLength(100);
            RuleFor(product => product.Price).GreaterThan(0);
            RuleFor(product => product.Description).NotEmpty().MaximumLength(500);
            RuleFor(product => product.Category).NotEmpty().MaximumLength(50);
            RuleFor(product => product.Image).NotEmpty().MaximumLength(500);

        }
    }
}
