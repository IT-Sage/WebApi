using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Domain
{
    public class Product
    {
        public Product(string name, string imgUri, decimal price)
        {
            Id = Guid.NewGuid();
            Name = name;
            ImgUri = imgUri;
            Price = price;
        }

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

        public string Description { get; set; }
    }
}
