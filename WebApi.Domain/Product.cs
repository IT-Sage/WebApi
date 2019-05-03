using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Domain
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        [Url]
        public Uri ImgUri { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public string Description { get; set; }
    }
}
