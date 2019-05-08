using Microsoft.AspNetCore.Builder;

namespace WebApi.Extensions
{
    public static class AppBuilderExtensions
    {
        public static IApplicationBuilder UseCustomizedSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API V1");                
            });

            return app;
        }
    }
}
