using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace ProductInventoryProject.Models
{
    public class ProductDetails
    {
        [Key]public int ProductId { get; set; }
        [Required]public string? ProductName { get; set; }
        [Required] public string? Category {  get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public   decimal Price  { get; set; }

        [Required]public int Quantity { get; set; }
        [Required]public string? Supplier {  get; set; }
        [Required]public DateTime ExpiryDate { get; set; }  
    }
}
