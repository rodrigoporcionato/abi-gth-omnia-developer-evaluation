using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.CreateProduct
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, CreateProductResult>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;


        public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<CreateProductResult> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productExists = await _productRepository.GetByNameAsync(request.Title, cancellationToken);
            if (productExists != null)
                throw new InvalidOperationException($"Product with name {request.Title} already exists");
            

            var product = _mapper.Map<Domain.Entities.Product>(request);
            var createdProduct = await _productRepository.CreateAsync(product, cancellationToken);

            var result = _mapper.Map<CreateProductResult>(createdProduct);

            return result;
        }
    }
}
