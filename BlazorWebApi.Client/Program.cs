
using Blazored.LocalStorage;
using BlazorWebApi.Client;
using BlazorWebApi.Client.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Serilog;
using Serilog.Extensions.Logging;
using System.Net.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
var httpClient = new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
};

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped(h => httpClient);
builder.Services.AddScoped<ToastrService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddAuthorizationCore();
//Serilog
var levelSwitch = new Serilog.Core.LoggingLevelSwitch();
Log.Logger = new LoggerConfiguration()
    .Enrich.WithProperty("InstanceId", Guid.NewGuid().ToString("n"))
    .WriteTo.BrowserHttp(httpClient)
    .CreateLogger();

builder.Logging.AddProvider(new SerilogLoggerProvider());


using var response = await httpClient.GetAsync("ProductSettings.json");
using var response1 = await httpClient.GetAsync("ProductSettings.Development.json");
using var response2 = await httpClient.GetAsync("ProductSettings.Production.json");
using var response3 = await httpClient.GetAsync("appsettings.json");
using var response4 = await httpClient.GetAsync("appsettings.Production.json");


using var stream = await response.Content.ReadAsStreamAsync();
using var stream1 = await response1.Content.ReadAsStreamAsync();
using var stream2 = await response2.Content.ReadAsStreamAsync();
using var stream3 = await response3.Content.ReadAsStreamAsync();
using var stream4 = await response4.Content.ReadAsStreamAsync();


builder.Configuration.AddJsonStream(stream);
builder.Configuration.AddJsonStream(stream1);
builder.Configuration.AddJsonStream(stream2);
builder.Configuration.AddJsonStream(stream3);
builder.Configuration.AddJsonStream(stream4);

await builder.Build().RunAsync();
