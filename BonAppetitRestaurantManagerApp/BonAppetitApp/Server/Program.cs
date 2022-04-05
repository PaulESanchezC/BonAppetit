using ServerConfigurations.ServerAuthenticationConfigurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#region Server Configurations

//Server Authentication Configurations
builder.Services.AddServerAuthenticationConfiguration();

#endregion

var app = builder.Build();

#region Server Http request pipeline

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

//Server Authentication
app.UseAuthentication();
app.UseBff();
app.UseAuthorization();

app.MapBffManagementEndpoints();

app.MapRazorPages();
app.MapControllers()
    .RequireAuthorization()
    .AsBffApiEndpoint(); ;
app.MapFallbackToFile("index.html");

#endregion

app.Run();
