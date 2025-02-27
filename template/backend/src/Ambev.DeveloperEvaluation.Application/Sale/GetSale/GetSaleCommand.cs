using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;

/// <summary>
/// Command for retrieving a sale by their ID
/// </summary>
public record GetSaleCommand : IRequest<GetSaleResult>
{
    /// <summary>
    /// The unique identifier of the sale to retrieve
    /// </summary>
    public int SaleId { get; }



    /// <summary>
    /// Initializes a new instance of sale comd
    /// </summary>
    /// <param name="id">The ID of the sale to retrieve</param>
    public GetSaleCommand(int saleId)
    {
        SaleId = saleId;
    }
}
