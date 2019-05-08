using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Controllers;
using WebApi.Data;
using WebApi.Mappers;
using WebApi.Models;

namespace Tests
{
    public class Tests
    {
        private DbContextOptionsBuilder<ProductContext> optionsBuilder;
        private IMapper mapper;

        [SetUp]
        public void Setup()
        {
            optionsBuilder = new DbContextOptionsBuilder<ProductContext>();
            optionsBuilder.UseInMemoryDatabase("HasSeedDataDb");

            var mappingConfig = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<ProductMappingProfile>();
            });

            mapper = mappingConfig.CreateMapper();
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

                ProductsController productsController = new ProductsController(context, mapper);
                var products = productsController.Get();
                
                Assert.That(products.Result, Is.InstanceOf(typeof(OkObjectResult)));
                Assert.That((products.Result as OkObjectResult).StatusCode, Is.EqualTo(200));

                List<ProductDto> productsList = (products.Result as OkObjectResult).Value as List<ProductDto>;
                Assert.That(5, Is.EqualTo(productsList.Count()));
            }
        }

        [Test]
        public void ReturnsCorrectProduct()
        {
            using (var context = new ProductContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();

                ProductsController productsController = new ProductsController(context, mapper);

                Guid id = new Guid("2136EAAD-4D96-435C-ABCC-7A3B549CFCDD");
                var product = productsController.Get(id);

                Assert.That(product.Result, Is.InstanceOf(typeof(OkObjectResult)));
                Assert.That((product.Result as OkObjectResult).StatusCode, Is.EqualTo(200));

                ProductDto productDto = (product.Result as OkObjectResult).Value as ProductDto;
                Assert.That(id, Is.EqualTo(productDto.Id));
                Assert.That("Keyboard", Is.EqualTo(productDto.Name));
            }
        }

        [Test]
        public void UpdatesProductCorrectly()
        {
            using (var context = new ProductContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();

                ProductsController productsController = new ProductsController(context, mapper);

                Guid id = new Guid("2136EAAD-4D96-435C-ABCC-7A3B549CFCDD");
                var productInitial = productsController.Get(id);
                ProductDto productDtoInitial = (productInitial.Result as OkObjectResult).Value as ProductDto;

                Assert.That("Asus", Is.Not.EqualTo(productDtoInitial.Description));
                
                var statusUpdated = productsController.UpdateDescription(id,"Asus");

                Assert.That(statusUpdated, Is.InstanceOf(typeof(NoContentResult)));
                Assert.That((statusUpdated as NoContentResult).StatusCode, Is.EqualTo(204));

                var productUpdated = productsController.Get(id);
                ProductDto productDtoUpdated = (productUpdated.Result as OkObjectResult).Value as ProductDto;

                Assert.That("Asus", Is.EqualTo(productDtoUpdated.Description));
            }
        }

        [Test]
        public void GetProductNotFound()
        {
            using (var context = new ProductContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();

                ProductsController productsController = new ProductsController(context, mapper);

                Guid id = Guid.Empty;
                var product = productsController.Get(id);

                Assert.That(product.Result, Is.InstanceOf(typeof(NotFoundResult)));
                Assert.That((product.Result as NotFoundResult).StatusCode, Is.EqualTo(404));
            }
        }

        [Test]
        public void UpdateDescriptionProductNotFound()
        {
            using (var context = new ProductContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();

                ProductsController productsController = new ProductsController(context, mapper);

                Guid id = Guid.Empty;
                var result = productsController.UpdateDescription(id,"description");

                Assert.That(result, Is.InstanceOf(typeof(NotFoundResult)));
                Assert.That((result as NotFoundResult).StatusCode, Is.EqualTo(404));
            }
        }
    }
}