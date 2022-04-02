using Blazored.LocalStorage;
using BonAppetitRestaurantManagerApp;
using Configurations.ServicesConfigurations;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


#region Services
//Services Configuration
builder.Services.AddServicesConfigurations();
//

//Http Client
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

#endregion
builder.Services.AddBlazoredLocalStorage();
await builder.Build().RunAsync();
