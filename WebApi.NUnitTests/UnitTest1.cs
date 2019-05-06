using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;
using WebApi.Data;

namespace Tests
{
    public class Tests
    {
        private DbContextOptionsBuilder<ProductContext> optionsBuilder;

        [SetUp]
        public void Setup()
        {
            optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
        }

        [Test]
        public void HasSeedData()
        {
            optionsBuilder.UseInMemoryDatabase("HasSeedDataDb");
            using (var context = new ProductContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();                
                Assert.That(0, Is.Not.EqualTo(context.Products.Count()));
            }
        }


    }
}