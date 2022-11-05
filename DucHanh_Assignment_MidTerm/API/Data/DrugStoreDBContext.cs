using API.Models;
using Microsoft.EntityFrameworkCore;
namespace API.Data
{
    public class DrugStoreDBContext : DbContext
    {
        public DbSet<Category> categories { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Customer> customers { get; set; }
        public DbSet<Rating> ratings { get; set; }
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
                .WithMany(g => g.products)
                .HasForeignKey(s => s.CategoryId)
                .HasConstraintName("FK_Product_Category");
            //add cascade delete for category on product
            modelBuilder.Entity<Category>()
                .HasMany<Product>(c => c.products)
                .WithOne(g => g.Category)
                .HasForeignKey(c => c.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            //add primary key for customer
            modelBuilder.Entity<Customer>()
                .HasKey(c => c.Id);
            //add primary key for rating
            modelBuilder.Entity<Rating>()
                .HasKey(c => c.Id);
            //add foreign key for rating
            modelBuilder.Entity<Rating>()
                .HasOne<Customer>(c => c.Customer)
                .WithMany(g => g.ratings)
                .HasForeignKey(s => s.CustomerId)
                .HasConstraintName("FK_Rating_Customer");
            modelBuilder.Entity<Rating>()
                .HasOne<Product>(c => c.Product)
                .WithMany(g => g.Ratings)
                .HasForeignKey(s => s.ProductId)
                .HasConstraintName("FK_Rating_Product");
            //add cascade delete for customer on rating
            modelBuilder.Entity<Customer>()
                .HasMany<Rating>(c => c.ratings)
                .WithOne(g => g.Customer)
                .HasForeignKey(c => c.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);
            //add cascade delete for product on rating
            modelBuilder.Entity<Product>()
                .HasMany<Rating>(c => c.Ratings)
                .WithOne(g => g.Product)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
