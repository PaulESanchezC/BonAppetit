using Configurations.AuthorizationConfigurations;
using Configurations.AutoMapperConfigurations;
using Configurations.ConfigurationsHelper;
using Configurations.CorsConfigurations;
using Configurations.DataAccessConfigurations;
using Configurations.JsonConfigurations;
using Configurations.PolicyAuthorizationConfigurations;
using Configurations.ServicesConfigurations;
using Configurations.SwaggerGenConfigurations;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

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
//Policy Authorization Configurations
services.AddPolicyServiceConfiguration();
//Authentication Configurations
services.AddAuthenticationConfigurations();
//Cors Configurations
services.AddCorsConfiguration();
//

#endregion



var app = builder.Build();

#region Http Pipeline

if (app.Environment.IsDevelopment())
{ }
app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/BonAppetitOpenApi/swagger.json", "Bon Appetit Restaurant Service"));
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
