using MediatR;
using Microsoft.Extensions.DependencyInjection;
using TaskBookPomo.Bootstrap.Helpers;

namespace TaskBookPomo.Bootstrap.Configuration
{
    public static class MediatRConfiguration
    {
        public static IServiceCollection AddMediatRWithAssemblyScanning(this IServiceCollection services) =>
            services.AddMediatR(assemblies: AssemblyScanning.GetAssemblies());
    }
}