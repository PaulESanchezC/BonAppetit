using Blazored.LocalStorage;
using BonAppetitManagerApp;
using Configurations.AutoMapperConfigurations;
using Configurations.OidcAuthenticationConfigurations;
using Configurations.ServicesConfigurations;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//#region Services Container
////AutoMapper Configurations
//builder.Services.AddAutoMapperMapConfigurations();
////Blazored Local Storage
//builder.Services.AddBlazoredLocalStorage();
////Oidc Authentication Configurations
//builder.Services.AddOidcAuthenticationConfigurations();
////Services Configurations 
//builder.Services.AddServicesConfigurations();


//#endregion

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
