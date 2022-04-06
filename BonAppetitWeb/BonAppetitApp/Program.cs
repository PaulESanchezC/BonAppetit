using Configurations.AuthenticationConfigurations;
using Configurations.ConfigurationsHelper;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

#region Service Container

//Configuration Helper
ProxyConfiguration.Initialize(builder.Configuration);
//Authentication Configurations
builder.Services.AddAuthenticationConfiguration();


#endregion



var app = builder.Build();
#region Http request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

#endregion

app.Run();
