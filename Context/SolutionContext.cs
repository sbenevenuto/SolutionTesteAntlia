using Microsoft.EntityFrameworkCore;

namespace Context
{
    public class SolutionContext : DbContext
    {
        public SolutionContext(DbContextOptions<SolutionContext> options)
            : base(options)
        { }

        public DbSet<Model.ManualMovement.ManualMovement> ManualMovements { get; set; }
        public DbSet<Model.Product.Product> Products { get; set; }
        public DbSet<Model.Product.ProductCosif> ProductCosif { get; set; }
    }
}
