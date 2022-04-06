using Configurations.ConfigurationsHelper;
using Configurations.CorsConfigurations;
using Configurations.DataAccessConfigurations;
using Configurations.IdentityConfigurations;
using Duende.IdentityServer.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var services = builder.Services;

#region Services Container

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

#endregion

var app = builder.Build();

#region Http Pipeline

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
    app.UseCors("Allow Anonymous");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.MapRazorPages();

app.MapControllers();

#endregion

app.Run();
