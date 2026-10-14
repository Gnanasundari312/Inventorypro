using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ProductInventorySystem.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string? ProductName { get; set; }

        [Required]
        public string? Category { get; set; }

        [Required]
        [Range(0, 1000000)]
        public decimal Price { get; set; }

        [Required]
        [Range(0, 100000)]
        [Precision(18, 2)]
        public int Quantity { get; set; }

        [Required]
        public string? Supplier { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
    }
}
