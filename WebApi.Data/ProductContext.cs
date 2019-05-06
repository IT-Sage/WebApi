using Microsoft.EntityFrameworkCore;
using System;
using WebApi.Domain;

namespace WebApi.Data
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        public ProductContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=AlzaWebApiData;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new 
                {
                    Id = new Guid("841796D4-80B8-484A-9A66-7BCCD0C4F296"),
                    Name = "USB Flash Disk",
                    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f4&cd=SASC022i1&i=1.jpg",
                    Price = 299m,
                    Description = "Speed of transfer up to 200MB/s"
                },
                new
                {
                    Id = new Guid("2136EAAD-4D96-435C-ABCC-7A3B549CFCDD"),
                    Name = "Keyboard",
                    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=FotoAddOrig&cd=MC001b1-02&i=1.jpg",
                    Price = 390m
                },
                new
                {
                    Id = new Guid("271FF3FA-6952-4D54-AB57-B525F4FBD66B"),
                    Name = "Mouse",
                    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f4&cd=ME362d2&i=1.jpg",
                    Price = 599m,
                    Description = "Battery life up to 9 months"
                },
                new
                {
                    Id = new Guid("EEFBCC21-72FD-41A0-A4C9-132F1ACEC395"),
                    Name = "Notebook",
                    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f4&cd=NA626d65&i=1.jpg",
                    Price = 31990m                    
                },
                new
                {
                    Id = new Guid("74F5110E-FDC7-4137-B064-BAFADC64B43A"),
                    Name = "Mobile Phone",
                    ImgUri = "https://cdn.alza.cz/ImgW.ashx?fd=f4&cd=SAMO0163b3&i=1.jpg",
                    Price = 6999m
                }
                );
        }
    }
}
