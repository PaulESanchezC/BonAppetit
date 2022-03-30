using Configurations.AutoMapperConfigurations;
using Configurations.ConfigurationsHelper;
using Configurations.DataAccessConfigurations;
using Configurations.JsonConfigurations;
using Configurations.ServicesConfigurations;
using Configurations.SwaggerGenConfigurations;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

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


var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ }
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
