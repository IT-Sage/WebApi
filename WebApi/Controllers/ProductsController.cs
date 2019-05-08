using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Data;
using WebApi.Domain;
using WebApi.Models;

namespace WebApi.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext context;
        private readonly IMapper mapper;
        
        public ProductsController(ProductContext context, IMapper mapper)            
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            List<Product> products = context.Products.ToList();
            IEnumerable<ProductDto> productDtos = mapper.Map<List<Product>, IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto> Get(Guid id)
        {
            Product product = context.Products.Where(p => p.Id == id).FirstOrDefault();
            ProductDto productDto = mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        public ActionResult UpdateDescription(Guid id, [FromBody] string description)
        {            
            context.Products.Where(p => p.Id == id).FirstOrDefault().Description = description;
            context.SaveChanges();
            return NoContent();
        }
    }
}
