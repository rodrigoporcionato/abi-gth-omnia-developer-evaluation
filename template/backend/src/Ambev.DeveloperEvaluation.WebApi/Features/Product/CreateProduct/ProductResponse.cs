namespace Ambev.DeveloperEvaluation.WebApi.Features.Product.ProductFeature
{
    public class ProductResponse
    {

        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public RatingResponse Rating { get; set; }
    }

    public class RatingResponse
    {
        public double Rate { get; set; }
        public int Count { get; set; }
    }
}
