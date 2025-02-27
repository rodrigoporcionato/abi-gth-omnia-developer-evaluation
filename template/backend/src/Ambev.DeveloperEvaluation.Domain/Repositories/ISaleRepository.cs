using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Repositories
{
    public interface ISaleRepository
    {
        Task<Sale> GetByIdAsync(int saleNumber, CancellationToken cancellationToken = default);
        Task AddSaleAsync(Sale sale, CancellationToken cancellationToken = default);
        Task UpdateSaleAsync(Sale sale, CancellationToken cancellationToken = default);
        Task<bool> DeleteSaleAsync(int saleNumber, CancellationToken cancellationToken = default);
    }
}
