using Configurations.AuthorizationConfigurations;
using Configurations.AutoMapperConfigurations;
using Configurations.ConfigurationsHelper;
using Configurations.CorsConfigurations;
using Configurations.DataAccessConfigurations;
using Configurations.JsonConfigurations;
using Configurations.ServicesConfigurations;
using Configurations.SwaggerGenConfigurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var services = builder.Services;
#region Services

services.AddHttpClient();
//AutoMapper Configurations
services.AddAutoMapperMapConfigurations();
//Configuration Helper -ProxyConfiguration-
ProxyConfiguration.Initialize(builder.Configuration);
//DataAccessConfigurations
services.AddDbContextOptions();
//Json Configurations
services.AddJsonConfigurations();
//SwaggerGen Configurations
services.AddSwaggerGenConfiguration();
//Services Configurations
services.AddServicesConfigurations();
//Cors Configurations
services.AddCorsConfiguration();
//Authentication Configurations
services.AddAuthenticationConfigurations();

#endregion

var app = builder.Build();

#region Http request pipeline

if (app.Environment.IsDevelopment()) { }
app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/BonAppetitOpenApi/swagger.json", "Bon Appetit Coupon Service"));
app.UseHttpsRedirection();
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


#endregion

app.Run();
