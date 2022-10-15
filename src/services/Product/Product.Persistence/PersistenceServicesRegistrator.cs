﻿//-----------------------------------------------------------------------------------
// <copyright file="PersistenceServicesRegistrator.cs" website="Patrikduch.com">
//     Copyright (c) Patrik Duch, IČ: 09225471
// </copyright>
// <author>Patrik Duch</author>
//-----------------------------------------------------------------------------------
namespace Product.Persistence;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Product.Persistence.Contexts;
using Product.Persistence.Seeders;

/// <summary>
/// Registration of persistence services.
/// </summary>
public static class PersistenceServicesRegistrator
{
    /// <summary>
    /// Definition of service sets that are being used by Persistence project.
    /// </summary>
    /// <param name="services">Service collection fo Dependency Injection Container.</param>
    /// <returns>Dependency Injection services collection.</returns>
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("DatabaseSettings:ConnectionString").Value;

        services.AddScoped<DbContext, ProductContext>();
        services.AddTransient<ProductSeeder>();



        services.AddDbContext<ProductContext>(options =>
            options.UseNpgsql((connectionString)));

        return services;
    }
}
