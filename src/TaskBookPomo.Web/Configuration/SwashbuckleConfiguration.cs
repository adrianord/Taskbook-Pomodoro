using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TaskBookPomo.Web.Configuration
{
    public static class SwashbuckleConfiguration
    {
        public const string DefaultVersion = "v1";

        public static IServiceCollection AddSwashbuckle(this IServiceCollection services, OpenApiInfo apiInfo) =>
            services.AddSwaggerGen(setupAction: c =>
            {
                c.CustomSchemaIds(schemaIdSelector: x => x.FullName); // Prevents conflicts with commonly named parameters
                c.DescribeAllParametersInCamelCase(); // Follow http parameter naming convention
                c.SwaggerDoc(name: apiInfo.Version, info: apiInfo);
                c.EnableAnnotations();
            });

        public static void UseSwashbuckle(this IApplicationBuilder app, string name,
            string apiVersion = DefaultVersion) =>
            app.UseSwagger()
               .UseSwaggerUI(setupAction: c =>
                   c.SwaggerEndpoint(url: $"/swagger/{apiVersion}/swagger.json", name: $"{name} {apiVersion.ToUpper()}"));
    }
}