

using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;

public class SaleCommand : IRequest<SaleResult>
{
    public string Customer { get; set; }
    public string Branch { get; set; }
    public List<SaleItem> Items { get; set; } = new List<SaleItem>();
}