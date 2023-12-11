using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;

public static class ApplicationServicesRegistration
{
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assembly);
        services.AddMediatR(assembly);

        
        return services;
    }
}