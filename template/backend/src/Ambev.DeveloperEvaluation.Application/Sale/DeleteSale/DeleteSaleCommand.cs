using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.DeleteSale;

/// <summary>
/// Command for deleting a user
/// </summary>
public record DeleteSaleCommand : IRequest<DeleteSaleResponse>
{
    /// <summary>
    /// The unique identifier of the sale to delete
    /// </summary>
    public int SaleNumber { get; }

    /// <summary>
    /// Initializes a new instance of DeleteUserCommand
    /// </summary>
    /// <param name="id">The ID of the user to delete</param>
    public DeleteSaleCommand(int saleNumber)
    {
        SaleNumber = saleNumber;
    }
}
