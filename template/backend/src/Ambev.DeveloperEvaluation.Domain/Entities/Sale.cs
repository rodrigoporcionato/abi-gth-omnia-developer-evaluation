 
 namespace Ambev.DeveloperEvaluation.Domain.Entities;

 public class Sale
    {
        public int SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string Branch { get; set; }
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();
        public decimal TotalAmount { get; set; }
        public bool IsCancelled { get; set; }

        public void CalculateTotal()
        {
            TotalAmount = 0;
            foreach (var item in Items)
            {
                item.ApplyDiscount();
                TotalAmount += item.Total;
            }
        }
    }