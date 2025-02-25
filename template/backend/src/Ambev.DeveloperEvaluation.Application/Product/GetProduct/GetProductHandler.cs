using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Application.Product.GetProduct
{
    public class GetProductHandler : IRequestHandler<GetProductCommand, List<GetProductResult>>
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public GetProductHandler(IProductRepository productRepo, IMapper mapper)
        {
            
            _productRepo = productRepo;
            _mapper = mapper;
        }

        /// <summary>
        /// get all products
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<GetProductResult>> Handle(GetProductCommand request, CancellationToken cancellationToken)
        {
            //todo: add redis cache
            var products = await _productRepo.GetAllAsync(cancellationToken);
            return _mapper.Map<List<GetProductResult>>(products);
        }

     
    }
}
