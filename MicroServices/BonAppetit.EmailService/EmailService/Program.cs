using Configurations.ConfigurationsHelper;
using Configurations.CorsConfigurations;
using Configurations.ServicesConfigurations;
using Configurations.SwaggerGenConfigurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

#region Service containers
//Configuration Helper -ProxyConfiguration-
ProxyConfiguration.Initialize(builder.Configuration);
//SwaggerGen Configurations
builder.Services.AddSwaggerGenConfiguration();
//Cors Configurations
builder.Services.AddCorsConfiguration();
// Services Configurations
builder.Services.AddRepositoryServicesConfigurations();
#endregion

var app = builder.Build();

#region Http request pipeline
if (app.Environment.IsDevelopment()) { }

app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/BonAppetitOpenApi/swagger.json", "Bon Appetit Email Service"));
app.UseCors("AllowAnonymous");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
#endregion

app.Run();
