using Blazored.LocalStorage;
using BonAppetitWebApp;
using Configurations.OidcAuthenticationConfigurations;
using Configurations.ServicesConfigurations;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

#region Services Container
//Blazored Local Storage
builder.Services.AddBlazoredLocalStorage();
//Oidc Authentication Configurations
builder.Services.AddOidcAuthenticationConfigurations();
//Services Configurations 
builder.Services.AddServicesConfigurations();

#endregion

await builder.Build().RunAsync();
