using Ambev.DeveloperEvaluation.Domain.Common;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Product : BaseEntity
{
    public string Title { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public Guid CategoryId { get; set; }  

    public ProductCategory Category { get; set; }
    public string Image { get; set; }

    public Guid RatingId { get; set; }
    public Rating Rating { get; set; }
}
