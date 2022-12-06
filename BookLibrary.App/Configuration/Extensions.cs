namespace BookLibrary.App.Configuration;

using System.Reflection;

using AutoMapper;

using MediatR;

using Microsoft.Extensions.DependencyInjection;

public static class Extensions
{
    private static Assembly Assembly => typeof(Extensions).Assembly;

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly);

        services.AddAutoMapper(typeof(MappingProfile));

        return services;
    }
}
