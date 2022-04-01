using Configurations.ConfigurationsHelper;
using Configurations.DataAccessConfigurations;
using Configurations.IdentityConfigurations;

#region WebAppBuilder

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
var services = builder.Services;

#endregion

#region Services Container

//Configuration Helper
ProxyConfiguration.Initialize(builder.Configuration);
//Data Access Configurations
services.AddDbContextOptions();
//Identity Configurations
services.AddIdentityConfigurationOptions();

#endregion

var app = builder.Build();

#region Http Pipeline

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();

app.MapRazorPages();
#endregion

app.Run();
