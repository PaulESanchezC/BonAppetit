using Configurations.ConfigurationsHelper;
using Configurations.DataAccessConfigurations;
using Configurations.JsonConfigurations;
using Configurations.ServicesConfigurations;
using Configurations.SwaggerGenConfigurations;

var builder = WebApplication.CreateBuilder(args);

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
//Json Configurations
builder.Services.AddJsonConfigurations();
//Services Configurations
builder.Services.AddServicesConfigurations();

#endregion

var app = builder.Build();

#region Http request pipeline

if (app.Environment.IsDevelopment()) { }
app.UseSwagger();
app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/BonAppetitOpenApi/swagger.json", "Bon Appetit Payment Service Api"));
app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

#endregion

app.Run();