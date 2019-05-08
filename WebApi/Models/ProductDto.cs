using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
    public class ProductDto
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.ImageUrl)]
        [Url]
        public string ImgUri { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.Text)]
        public string Description { get; set; }
    }
}
