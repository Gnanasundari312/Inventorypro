using Microsoft.EntityFrameworkCore;

namespace ProductInventoryProject.Models.Data
{
    public class ProductsallDbContext : DbContext

    {
        public ProductsallDbContext(DbContextOptions<ProductsallDbContext> options):base (options) 
        { 
        }
        public DbSet<ProductDetails> ProductTable {  get; set; }
    }
}
