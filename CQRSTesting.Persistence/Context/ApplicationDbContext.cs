using CQRSTesting.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRSTesting.Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        // Nos permite recibir las opciones de configuración de la base de datos desde un componente externo (Api/startup)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Definimos las tablas de la base de datos
        public DbSet<Product> Products { get; set; }
         
        // Configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuration for Product 
            modelBuilder.Entity<Product>().Property(p => p.UnitPrice).HasPrecision(14, 2);


            // Seed Data
            modelBuilder.Entity<Product>().HasData(
             new Product { ProductId = Guid.NewGuid(), Description = "Test Product", Name = "Product 1", DateCreated = DateTime.Now, DatePublished = DateTime.Now.AddDays(1), UnitPrice = 100 });

            modelBuilder.Entity<Product>().HasData(
              new Product { ProductId = Guid.NewGuid(), Description = "Test Product", Name = "Product 2", DateCreated = DateTime.Now, DatePublished = DateTime.Now.AddDays(1), UnitPrice = 120 });

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = Guid.NewGuid(), Description = "Test Product", Name = "Product 3", DateCreated = DateTime.Now, DatePublished = DateTime.Now.AddDays(1), UnitPrice = 500 });

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = Guid.NewGuid(), Description = "Test Product", Name = "Product 4", DateCreated = DateTime.Now, DatePublished = DateTime.Now.AddDays(1), UnitPrice = 80 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
