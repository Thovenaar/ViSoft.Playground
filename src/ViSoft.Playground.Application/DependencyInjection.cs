using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ViSoft.Playground.Application;

public static class DependencyInjection
{
    public static IServiceCollection RegisterApplicationLayer(this IServiceCollection services)
    {
        var assembly = typeof(DependencyInjection).Assembly;
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly));

        services.AddValidatorsFromAssembly(assembly);

        return services;
    }
}