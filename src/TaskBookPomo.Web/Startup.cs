using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TaskBookPomo.Bootstrap.Configuration;
using TaskBookPomo.Common.Constants;
using TaskBookPomo.Web.Configuration;

namespace TaskBookPomo.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddHelpers();
            services.AddMediatRWithAssemblyScanning();
            services.AddSwashbuckle(apiInfo: new OpenApiInfo
            {
                Title = ApplicationInfo.ApiName,
                Version = SwashbuckleConfiguration.DefaultVersion
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseSwashbuckle(name: ApplicationInfo.ApiName);

            app.UseRouting()
               .UseEndpoints(configure: endpoints => endpoints.MapControllers())
               .UseWebFrontend(env: env, contentRoot: "ClientApp");
        }
    }
}