
using Ambev.DeveloperEvaluation.Domain.Entities;

public class SaleResult
    {
        public int SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string Branch { get; set; }
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();
        public decimal TotalAmount { get; set; }

        public void CalculateTotal()
        {
            TotalAmount = Items.Sum(item =>
            {
                item.ApplyDiscount();
                return item.Total;
            });
        }
    }
    