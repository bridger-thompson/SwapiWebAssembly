using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAssemblyTest.Client;
using WebAssemblyTest.Client.CustomUser;
using WebAssemblyTest.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("WebAssemblyTest.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("WebAssemblyTest.ServerAPI"));
builder.Services.AddScoped<CustomAccountFactory>();

builder.Services.AddMsalAuthentication<RemoteAuthenticationState,
    CustomUserAccount>(options =>
{
    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://ethanwhittaker.onmicrosoft.com/feffb56d-9d49-42dd-b049-c316e8bb0ef2/API.Access");
    options.ProviderOptions.LoginMode = "redirect";
})
    .AddAccountClaimsPrincipalFactory<RemoteAuthenticationState, CustomUserAccount, CustomAccountFactory>();

//builder.Services.AddMsalAuthentication(options =>
//{
//    builder.Configuration.Bind("AzureAdB2C", options.ProviderOptions.Authentication);
//    options.ProviderOptions.DefaultAccessTokenScopes.Add("https://ethanwhittaker.onmicrosoft.com/feffb56d-9d49-42dd-b049-c316e8bb0ef2/API.Access");
//    options.ProviderOptions.LoginMode = "redirect";
//});

builder.Services.AddHttpClient<SwapiService>(
    client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
    .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

await builder.Build().RunAsync();
