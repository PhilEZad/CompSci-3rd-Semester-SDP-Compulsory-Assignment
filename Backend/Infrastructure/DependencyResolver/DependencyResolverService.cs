﻿using Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyResolver;

public static class DependencyResolverService
{
    public static void RegisterInfrastructureLayer(IServiceCollection services)
    {
        services.AddScoped<IBoxRepository, BoxRepository>();
    }
}