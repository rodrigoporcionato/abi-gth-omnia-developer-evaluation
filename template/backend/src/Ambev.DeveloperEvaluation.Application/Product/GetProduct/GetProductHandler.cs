using Ambev.DeveloperEvaluation.Cache;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductCommand, List<GetProductResult>>
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        private readonly IMemoryCacheService _memoryCache;



        public GetProductHandler(IProductRepository productRepo, IMapper mapper, IMemoryCacheService memoryCache)
        {
            
            _productRepo = productRepo;
            _mapper = mapper;
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// get all products
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<GetProductResult>> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {

            var cacheKey = "prdchachekey";

            var cachedProducts = await _memoryCache.GetAsync<List<GetProductResult>>(cacheKey);
            if (cachedProducts != null)
            {
                return cachedProducts;
            }

            var products = await _productRepo.GetAllAsync(cancellationToken);

            var mappedProducts = _mapper.Map<List<GetProductResult>>(products);
            await _memoryCache.SetAsync(cacheKey, mappedProducts, TimeSpan.FromMinutes(10));


            return _mapper.Map<List<GetProductResult>>(products);
        }

     
    }
}
