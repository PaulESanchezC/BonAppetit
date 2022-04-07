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

#region Service Container

//Configuration Helper
ProxyConfiguration.Initialize(builder.Configuration);
//Data Access Configurations
builder.Services.AddDbContextOptions();
//SwaggerGenConfigurations
builder.Services.AddSwaggerGenConfiguration();
//Cors Configurations
builder.Services.AddCorsConfiguration();
//Json Configurations
builder.Services.AddJsonConfigurations();
//Auto Mapper Configurations
builder.Services.AddAutoMapperMapConfigurations();
//Services Configurations
builder.Services.AddServicesConfigurations();

#endregion


var app = builder.Build();

#region Http request pipeline

if (app.Environment.IsDevelopment())
{ }

app.UseSwagger();
app.UseSwaggerUI();

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
