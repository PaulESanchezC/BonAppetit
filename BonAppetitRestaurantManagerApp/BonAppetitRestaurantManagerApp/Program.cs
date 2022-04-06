using Blazored.LocalStorage;
using BonAppetitRestaurantManagerApp;
using Configurations.AuthenticationConfigurations;
using Configurations.ServicesConfigurations;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


#region Services

//Blazor Local Storage
builder.Services.AddBlazoredLocalStorage();
//Services Configuration
builder.Services.AddServicesConfigurations();
//Authentication Configurations
builder.Services.AddAuthenticationConfiguration();
//Http Client
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#endregion
await builder.Build().RunAsync();
