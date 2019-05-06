using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Domain;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;
         
        public ProductsController(ProductContext context)
        {
            _context = context;
        }
                
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _context.Products.ToList();
        }
                
        [HttpGet("{id}")]
        public ActionResult<Product> Get(Guid id)
        {
            return _context.Products.Where(p => p.Id == id).FirstOrDefault();
        }
               
        [HttpPatch("{id}")]
        public ActionResult UpdateDescription(Guid id, [FromBody] string description)
        {
            return Ok();            
        }
    }
}
