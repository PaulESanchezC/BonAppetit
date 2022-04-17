using Configurations.AutoMapperConfigurations;
using Configurations.ConfigurationsHelper;
using Configurations.CorsConfigurations;
using Configurations.DataAccessConfigurations;
using Configurations.IdentityConfigurations;
using Configurations.ServicesConfigurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
var services = builder.Services;

#region Services Container
//AutoMapper Configurations
services.AddAutoMapperMapConfigurations();
//Configuration Helper
ProxyConfiguration.Initialize(builder.Configuration);
//Data Access Configurations
services.AddDbContextOptions();
//Identity Configurations
services.AddIdentityConfigurationOptions();
//Razor pages
services.AddRazorPages();
//CorsConfigurations
services.AddCorsConfiguration();
//Services Configurations
services.AddServicesConfigurations();

#endregion

var app = builder.Build();

#region Http Pipeline

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseCors("AllowAnonymous");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();

#endregion

app.Run();
