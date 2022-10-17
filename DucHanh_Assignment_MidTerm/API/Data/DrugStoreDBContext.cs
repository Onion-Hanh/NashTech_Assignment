using CommonModel;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DrugStoreDBContext : DbContext
    {
        public DbSet<Catagory> cataogies { get; set; }
        public DbSet<Product> products { get; set; }
        public DrugStoreDBContext(DbContextOptions<DrugStoreDBContext> options)
            : base(options)
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
