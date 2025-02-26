

using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Users.GetUser;
using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


/// <summary>
/// Sale handler class responsible for handling the sale command and process orders
/// </summary>
public class SaleHandler : IRequestHandler<SaleCommand, SaleResult>
{
    private static int _saleNumber = 1;
    private readonly ILogger<SaleHandler> _logger;
    private readonly ISaleValidator _saleValidator;
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;


    public SaleHandler(ILogger<SaleHandler> logger, IProductRepository productRepository, IUserRepository userRepository, IMapper mapper, ISaleValidator saleValidator)
    {
        _logger = logger;
        _productRepository = productRepository;
        _userRepository = userRepository;
        _mapper = mapper;
        _saleValidator = saleValidator;
    }


    /// <summary>
    /// process sales by handle
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<SaleResult> Handle(SaleCommand request, CancellationToken cancellationToken)
    {
        //var validator = new SaleValidator();
        //var validationResult = await validator.ValidateAsync(request, cancellationToken);

        //if (!validationResult.IsValid)
        //    throw new ValidationException(validationResult.Errors);

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

        return sale;
    }

}