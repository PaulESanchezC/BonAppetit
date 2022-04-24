using Configurations.AutoMapperConfigurations;
using Configurations.ConfigurationsHelper;
using Configurations.CorsConfigurations;
using Configurations.DataAccessConfigurations;
using Configurations.IdentityConfigurations;
using Configurations.JsonConfigurations;
using Configurations.ServicesConfigurations;
using Configurations.SwaggerGenConfigurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var services = builder.Services;

#region Services

services.AddHttpClient();
//Configuration Helper -ProxyConfiguration-
ProxyConfiguration.Initialize(builder.Configuration);
//AutoMapper Configurations
services.AddAutoMapperMapConfigurations();
//Cors Configurations
services.AddCorsConfiguration();
//Data Access Configurations
services.AddDbContextOptions();
//Identity Configurations
services.AddIdentityConfigurationOptions();
//Json Configurations
services.AddJsonConfigurations();
//Services Configurations
services.AddServicesConfigurations();
//SwaggerGen Configurations
services.AddSwaggerGenConfiguration();

#endregion

builder.Services.AddSwaggerGen();
var app = builder.Build();

#region Http request pipeline

if (app.Environment.IsDevelopment()) { }
app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/BonAppetitOpenApi/swagger.json", "Bon Appetit Registration Service"));
app.UseHttpsRedirection();
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.UseAuthorization();
app.MapControllers();

#endregion
app.Run();
