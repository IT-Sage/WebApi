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
    /// <summary>
    /// Handling product requests.
    /// </summary>    
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

        /// <summary>
        /// Returns all product in the database.
        /// </summary>
        /// <returns>All products in the database.</returns>
        /// <response code="200">In case of correct request.</response>
        /// <response code="400">If the request is incorrect.</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]        
        public ActionResult<IEnumerable<ProductDto>> Get()
        {
            List<Product> products = context.Products.ToList();
            IEnumerable<ProductDto> productDtos = mapper.Map<List<Product>, IEnumerable<ProductDto>>(products);
            return Ok(productDtos);
        }

        /// <summary>
        /// Returns one product specified by id.
        /// </summary>
        /// <param name="id">Guid Id of the product.</param>        
        /// <returns>Requested product.</returns>
        /// <response code="200">In case of correct request.</response>
        /// <response code="400">If the request is incorrect.</response>
        /// <response code="404">If the product does not exist.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]        
        public ActionResult<ProductDto> Get(Guid id)
        {
            Product product = context.Products.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }

            ProductDto productDto = mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        /// <summary>
        /// Updates description of the product specified by id.
        /// </summary>
        /// <param name="id">Guid Id of the product.</param>
        /// <param name="description">New description. Provide it in <b>quotation marks</b>.</param>
        /// <returns>Status message</returns>        
        /// <response code="204">In case of correct request.</response>
        /// <response code="400">If the request is incorrect.</response>
        /// <response code="404">If the product does not exist.</response>
        [HttpPatch("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]        
        public ActionResult UpdateDescription(Guid id, [FromBody] string description)
        {
            Product product = context.Products.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                return NotFound();
            }
            product.Description = description;
            context.SaveChanges();

            return NoContent();
        }
    }
}
