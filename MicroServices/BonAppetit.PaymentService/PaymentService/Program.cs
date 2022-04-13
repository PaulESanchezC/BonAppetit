using Configurations.AutoMapperConfigurations;
using Configurations.ConfigurationsHelper;
using Configurations.CorsConfigurations;
using Configurations.DataAccessConfigurations;
using Configurations.ServicesConfigurations;
using Configurations.SwaggerGenConfigurations;
using Stripe;

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
//Cors Configurations
builder.Services.AddCorsConfiguration();
#endregion

var app = builder.Build();


#region Http request pipeline

if (app.Environment.IsDevelopment()) { }
app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/BonAppetitOpenApi/swagger.json", "Bon Appetit Payment Service"));
app.UseHttpsRedirection();
app.UseCors("AllowAnonymous");

StripeConfiguration.ApiKey = ProxyConfiguration.Use.GetSection("Stripe:SecretKey").Value;

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();
