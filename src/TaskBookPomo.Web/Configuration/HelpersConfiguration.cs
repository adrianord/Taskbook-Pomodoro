using Microsoft.Extensions.DependencyInjection;
using TaskBookPomo.Common.Helpers;

namespace TaskBookPomo.Web.Configuration
{
    public static class HelpersConfiguration
    {
        public static IServiceCollection AddHelpers(this IServiceCollection serviceCollection) =>
            serviceCollection.AddSingleton<IAboutInfoHelper, AboutInfoHelper>();
    }
}