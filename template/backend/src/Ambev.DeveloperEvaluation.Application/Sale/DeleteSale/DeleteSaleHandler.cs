using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Sale.DeleteSale;

/// <summary>
/// Handler for processing sale command requests
/// </summary>
public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
{
    private readonly ISaleRepository _saleRepo;

    /// <summary>
    /// Initializes a new instance of DeleteSaleHandler
    /// </summary>
    /// <param name="saleRepo">The user repository</param>
    /// <param name="validator">The validator for DeleteUserCommand</param>
    public DeleteSaleHandler(
        ISaleRepository saleRepo)
    {
        _saleRepo = saleRepo;
    }

    /// <summary>
    /// Handles the DeleteUserCommand request
    /// </summary>
    /// <param name="request">The DeleteUser command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSaleResponse> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _saleRepo.DeleteSaleAsync(request.SaleNumber, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Sale num. {request.SaleNumber} not found");

        return new DeleteSaleResponse { Success = true };
    }
}
