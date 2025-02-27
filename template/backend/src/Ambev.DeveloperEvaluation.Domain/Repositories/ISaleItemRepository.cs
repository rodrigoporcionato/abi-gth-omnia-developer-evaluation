using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleItemRepository
    {
        Task AddSaleItemAsync(SaleItem saleItem, CancellationToken cancellationToken = default);
        Task UpdateSaleItemAsync(SaleItem saleItem, CancellationToken cancellationToken = default);
        Task DeleteSaleItemAsync(Guid saleItemId, CancellationToken cancellationToken = default);
        Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
