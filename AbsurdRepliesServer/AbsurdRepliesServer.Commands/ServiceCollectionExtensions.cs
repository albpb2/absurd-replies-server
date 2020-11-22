using System.Linq;
using AbsurdRepliesServer.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace AbsurdRepliesServer.Commands
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterCommands(this IServiceCollection services)
        {
            var assemblies = new[] {typeof(ServiceCollectionExtensions).Assembly};
            var typesFromAssemblies = assemblies.SelectMany(
                a => a.DefinedTypes.Where(x => x.BaseType?.GetInterfaces().Contains(typeof(ICommandHandler)) ?? false));
            foreach (var type in typesFromAssemblies)
                services.Add(new ServiceDescriptor(typeof(ICommandHandler), type, ServiceLifetime.Singleton));
            services.AddSingleton<CommandBus>();
        }
    }
}