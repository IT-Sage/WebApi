using AutoMapper;
using WebApi.Domain;
using WebApi.Models;

namespace WebApi.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
        

    }
}
