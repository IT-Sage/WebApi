using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Data;
using WebApi.Mappers;

namespace WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("AlzaConnection");
            services.AddDbContext<ProductContext>(options => options.UseSqlServer(connectionString));

            return services;
        }

        public static IServiceCollection AddCustomizedAutoMapper(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(configuration =>
            {
                configuration.AddProfile<ProductMappingProfile>();
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
