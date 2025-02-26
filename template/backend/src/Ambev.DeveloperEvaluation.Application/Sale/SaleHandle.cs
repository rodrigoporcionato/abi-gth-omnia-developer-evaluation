

using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;


/// <summary>
/// Sale handler class responsible for handling the sale command and process orders
/// </summary>
public class SaleHandler : IRequestHandler<SaleCommand, SaleResult>
{
    private static int _saleNumber = 1;
    private readonly ILogger<SaleHandler> _logger;

    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;


    public SaleHandler(ILogger<SaleHandler> logger, IProductRepository productRepository, IUserRepository userRepository, IMapper mapper)
    {
        _logger = logger;
        _productRepository = productRepository;
        _userRepository = userRepository;
        _mapper = mapper;

    }

    public async Task<SaleResult> Handle(SaleCommand request, CancellationToken cancellationToken)
    {

        //todo: validator here!


        ///find products by iods
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

        //todo: save sales to database
        var sale = new Sale
        {
            SaleNumber = _saleNumber++,
            Date = DateTime.UtcNow,
            Customer = new(),
            Branch = request.Branch,
            Items = request.Items,
        };
        sale.CalculateTotal();

        _logger.LogInformation($"SaleCreated: {sale.SaleNumber}");
        return _mapper.Map<SaleResult>(sale);        
    }
}