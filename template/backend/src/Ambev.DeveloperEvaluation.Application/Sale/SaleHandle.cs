

using MediatR;
using Microsoft.Extensions.Logging;


/// <summary>
/// Sale handler class responsible for handling the sale command and process orders
/// </summary>
public class SaleHandler : IRequestHandler<SaleCommand, SaleResult>
{
    public static List<SaleResult> Sales = new();
    private static int _saleNumber = 1;
    private readonly ILogger<SaleHandler> _logger;

    public SaleHandler(ILogger<SaleHandler> logger)
    {
        _logger = logger;
    }

    public Task<SaleResult> Handle(SaleCommand request, CancellationToken cancellationToken)
    {
        var sale = new SaleResult
        {
            SaleNumber = _saleNumber++,
            Date = DateTime.UtcNow,
            Customer = request.Customer,
            Branch = request.Branch,
            Items = request.Items,
        };
        sale.CalculateTotal();
        Sales.Add(sale);
        _logger.LogInformation($"SaleCreated: {sale.SaleNumber}");
        return Task.FromResult(sale);
    }
}