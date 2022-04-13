using Configurations.AutoMapperConfigurations;
using Configurations.ConfigurationsHelper;
using Configurations.DataAccessConfigurations;
using Configurations.ServicesConfigurations;
using Configurations.SwaggerGenConfigurations;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Service container
services.AddHttpClient();
//AutoMapper Configurations
services.AddAutoMapperMapConfigurations();
//Configuration Helper -ProxyConfiguration-
ProxyConfiguration.Initialize(builder.Configuration);
//SwaggerGen Configurations
services.AddSwaggerGenConfiguration();
//Services Configurations
services.AddServicesConfigurations();
//DataAccessConfigurations
services.AddDbContextOptions();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) { }
app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/BonAppetitOpenApi/swagger.json", "Bon Appetit Payment Service"));
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
