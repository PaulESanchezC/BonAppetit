using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using StaticData;

namespace Configurations.SwaggerGenConfigurations;

public static class SwaggerGenConfiguration
{
    public static IServiceCollection AddSwaggerGenConfiguration(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("BonAppetitOpenApi",
                new OpenApiInfo()
                {
                    Title = "Bon Appetit Email Service Service API",
                    Version = "V1.0",
                    Description = @"Bon Appetit microservices <br/> 
                                   <a href='https://localhost:44343/'>Bon Appetit client App</a> <br/>
                                   <a href='https://localhost:44310/swagger/index.html'>Restaurant Service</a> <br/>
                                   <a href='https://localhost:44314/swagger/index.html'>Reservation Service</a> <br/> 
                                   <a href='https://localhost:44303/swagger/index.html'>Payment Service</a> <br/> 
                                   <a href='https://localhost:44360/swagger/index.html'>Email Service</a> <br/> ",
                    Contact = new OpenApiContact()
                    {
                        Name = "Paul Sanchez",
                        Email = "PaulESanchezC@outlook.com"
                    }
                });
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
