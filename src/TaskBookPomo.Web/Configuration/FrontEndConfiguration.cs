using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace TaskBookPomo.Web.Configuration
{
    
    public static class FrontEndConfiguration
    {
        public static IApplicationBuilder UseWebFrontend(this IApplicationBuilder app, IWebHostEnvironment env, string contentRoot)
        {
            if (env.IsDevelopment())
            {
                app.UseSpa(configuration: spa => { spa.UseProxyToSpaDevelopmentServer(baseUri: "http://localhost:4200"); });
                return app;
            }

            var provider = new ManifestEmbeddedFileProvider(assembly: Assembly.GetAssembly(type: typeof(Startup)), root: contentRoot);
            app.UseSpaStaticFiles(options: new StaticFileOptions
            {
                FileProvider = provider,
                RequestPath = "",
            });
            return app;
        }
    }
}