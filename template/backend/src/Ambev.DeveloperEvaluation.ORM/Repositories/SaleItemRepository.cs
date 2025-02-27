using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{

    public class SaleItemRepository : ISaleItemRepository
    {

        private readonly DefaultContext _context;

        public SaleItemRepository(DefaultContext context)
        {
            _context = context;
        }

        public async Task AddSaleItemAsync(SaleItem saleItem, CancellationToken cancellationToken = default)
        {
            await _context.SaleItems.AddAsync(saleItem, cancellationToken);
        }

        public async Task DeleteSaleItemAsync(Guid saleId, CancellationToken cancellationToken = default)
        {
            var saleItem = await GetByIdAsync(saleId, cancellationToken);
            if (saleItem != null)
            {
                _context.SaleItems.Remove(saleItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<SaleItem?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await _context.SaleItems.FirstOrDefaultAsync(x=> x.Id == id, cancellationToken);
        }

        public async Task UpdateSaleItemAsync(SaleItem item, CancellationToken cancellationToken = default)
        {
            _context.SaleItems.Update(item);
            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
