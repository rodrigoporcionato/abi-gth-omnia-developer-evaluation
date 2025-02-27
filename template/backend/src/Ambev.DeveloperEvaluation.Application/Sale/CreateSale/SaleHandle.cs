using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Sale handler class responsible for handling the sale command and process orders
/// </summary>
public class SaleHandler : IRequestHandler<SaleCommand, SaleResult>
{
    private readonly ILogger<SaleHandler> _logger;
    private readonly ISaleValidator _saleValidator;
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private readonly ISaleRepository _saleRepository;


    public SaleHandler(ILogger<SaleHandler> logger, 
        IProductRepository productRepository,
        IUserRepository userRepository, IMapper mapper,
        ISaleValidator saleValidator, 
        ISaleRepository saleRepository
        )
    {
        _logger = logger;
        _productRepository = productRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _saleValidator = saleValidator;
        _saleRepository = saleRepository;
    }

    /// <summary>
    /// process sales by handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<SaleResult> Handle(SaleCommand request, CancellationToken cancellationToken)
    {     
        await _saleValidator.ValidateAndThrowAsync(request, cancellationToken);
        return _mapper.Map<SaleResult>(await ProcessSaleAsync(request, cancellationToken));        
    }


    /// <summary>
    /// validate items and find by user/ at the end save product
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    private async Task<Sale> ProcessSaleAsync(SaleCommand request, CancellationToken cancellationToken) {

        var prodIds = request.Items.Select(i => i.ProductId).ToList();
        var products = await _productRepository.GetByIdsAsync(prodIds, cancellationToken);
        var productDict = products.ToDictionary(p => p.Id);

        foreach (var item in request.Items)
        {
            if (!productDict.TryGetValue(item.ProductId, out var product))
            {
                throw new InvalidOperationException($"Product with id {item.ProductId} not found");
            }
            item.Product = product;
        }

        //in real cenarios it is not recomend to create a random number, but is only for test purpose.
        var random = new Random();
        int saleNumber = random.Next(100000, 999999);
        var sale = new Domain.Entities.Sale
        {
            SaleNumber = saleNumber,
            Date = DateTime.UtcNow,
            Customer = new(),
            Branch = request.Branch,
            Items = request.Items,
        };
        sale.CalculateTotal();

        await _saleRepository.AddSaleAsync(sale, cancellationToken);


        return sale;
    }

}