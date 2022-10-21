using API.Models;
using Microsoft.EntityFrameworkCore;
namespace API.Data
{
    public class DrugStoreDBContext : DbContext
    {
        public DbSet<Category> categories { get; set; }
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
            //add primary key for category
            modelBuilder.Entity<Category>()
                .HasKey(c => c.Id);
            //add primary key for product
            modelBuilder.Entity<Product>()
                .HasKey(c => c.Id);
            //add foreign key for product
            modelBuilder.Entity<Product>()
                .HasOne<Category>(c => c.Category)
                .WithMany(g=>g.products)
                .HasForeignKey(s => s.CategoryId);
            //add cascade delete for category
            modelBuilder.Entity<Category>()
                .HasMany<Product>(c => c.products)
                .WithOne(g => g.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
