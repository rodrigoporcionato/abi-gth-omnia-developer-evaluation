using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string category { get; set; }  
    public string Image { get; set; }
    public decimal Rating { get; set; }
    public int RatingCount { get; set; }
}
