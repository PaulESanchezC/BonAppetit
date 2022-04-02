using Configurations.AuthorizationConfigurations;
using Configurations.AutoMapperConfigurations;
using Configurations.ConfigurationsHelper;
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

#endregion

var app = builder.Build();

#region Http Pipeline

if (app.Environment.IsDevelopment())
{ }
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

#endregion

app.Run();
