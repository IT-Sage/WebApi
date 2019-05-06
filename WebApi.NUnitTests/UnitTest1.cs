using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Controllers;
using WebApi.Data;
using WebApi.Domain;

namespace Tests
{
    public class Tests
    {
        private DbContextOptionsBuilder<ProductContext> optionsBuilder;

        [SetUp]
        public void Setup()
        {
            optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
            optionsBuilder.UseInMemoryDatabase("HasSeedDataDb");
        }

        [Test]
        public void HasSeedData()
        {            
            using (var context = new ProductContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();                
                Assert.That(0, Is.Not.EqualTo(context.Products.Count()));
            }
        }

        [Test]
        public void ReturnsProducts()
        {
            using (var context = new ProductContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
                ProductsController productsController = new ProductsController(context);

                var products = productsController.Get();
                
                Assert.That(5, Is.EqualTo(products.Value.Count()));
            }
        }

        [Test]
        public void ReturnsCorrectProduct()
        {
            using (var context = new ProductContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();
                ProductsController productsController = new ProductsController(context);

                Guid id = new Guid("2136EAAD-4D96-435C-ABCC-7A3B549CFCDD");

                var product = productsController.Get(id);
                
                Assert.That(id, Is.EqualTo(product.Value.Id));
                Assert.That("Keyboard", Is.EqualTo(product.Value.Name));
            }
        }


    }
}