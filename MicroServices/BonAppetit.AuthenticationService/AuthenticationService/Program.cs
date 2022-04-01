using Configurations.ConfigurationsHelper;
using Configurations.DataAccessConfigurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var services = builder.Services;
var app = builder.Build();
//Configuration Helper
ProxyConfiguration.Initialize(builder.Configuration);
//Data Access Configurations
services.AddDbContextOptions();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
