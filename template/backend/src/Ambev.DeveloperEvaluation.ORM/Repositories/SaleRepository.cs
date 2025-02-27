using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.ORM.Repositories
{
    public class SaleRepository : ISaleRepository
    {

        private readonly DefaultContext _context;

        public SaleRepository(DefaultContext context)
        {
            _context = context;
        }
 
        public async Task AddSaleAsync(Sale sale, CancellationToken cancellationToken = default)
        {
           _context.Sales.Add(sale);
           await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<bool> DeleteSaleAsync(int saleNumber, CancellationToken cancellationToken = default)
        {
            var sale = await GetByIdAsync(saleNumber, cancellationToken);
            if (sale != null)
            {
                _context.Sales.Remove(sale);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<Sale?> GetByIdAsync(int saleNumber, CancellationToken cancellationToken = default)
        {
            return await _context.Sales
                .Include(i=> i.Items).ThenInclude(p=> p.Product)
                .FirstOrDefaultAsync(x => x.SaleNumber == saleNumber, cancellationToken);
        }

        public async Task UpdateSaleAsync(Sale sale, CancellationToken cancellationToken = default)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync(cancellationToken);

        }
    }
}
