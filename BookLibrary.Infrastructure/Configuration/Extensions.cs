﻿namespace BookLibrary.Infrastructure.Configuration;

using BookLibrary.Core.Authors;
using BookLibrary.Core.Books;
using BookLibrary.Core.Categories;
using BookLibrary.Infrastructure.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

public static class Extensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, InfrastructureSettings settings)
    {
        services.AddSingleton(settings);

        services.AddDbContext<BookContext>(
            options => options.UseSqlServer(settings.Database.ConnectionString));

        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();

        return services;
    }
}
