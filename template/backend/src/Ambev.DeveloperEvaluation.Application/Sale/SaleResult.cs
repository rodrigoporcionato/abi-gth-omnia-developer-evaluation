
using Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Sale result class responsible for handling the sale result
/// </summary>
public class SaleResult
    {
        public int SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public string Customer { get; set; }
        public string Branch { get; set; }
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();
        public decimal TotalAmount { get; set; }

        /// <summary>
        /// Calucate the total amount of the sale
        /// </summary>
        public void CalculateTotal()
        {
            TotalAmount = Items.Sum(item =>
            {
                item.ApplyDiscount();
                return item.Total;
            });
        }
    }
    