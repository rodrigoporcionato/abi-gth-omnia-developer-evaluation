
namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.ProductFeature
{
    public class ProductRequest
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public RatingRequest Rating { get; set; }
    }

    public class RatingRequest
    {
        public double Rate { get; set; }
        public int Count { get; set; }
    }
}

