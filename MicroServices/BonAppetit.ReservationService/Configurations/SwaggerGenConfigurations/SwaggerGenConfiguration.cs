﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using StaticData;

namespace Configurations.SwaggerGenConfigurations;

public static class SwaggerGenConfiguration
{
    public static IServiceCollection AddSwaggerGenConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition(JwtBearerOptions.AuthenticationScheme, new OpenApiSecurityScheme
            {
                Description = @"Enter 'Bearer' [space] Token value",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = JwtBearerOptions.AuthenticationScheme
            });
            options.AddSecurityRequirement(
                new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerOptions.AuthenticationScheme
                            },
                            Scheme = "auth 2",
                            Name = JwtBearerOptions.AuthenticationScheme,
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
        });
        return services;
    }
}
