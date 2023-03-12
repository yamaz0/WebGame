using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Reflection;
using WebGame.UI.Blazor;
using WebGame.UI.Blazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.AddBlazoredLocalStorage();
builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });

builder.Services.AddScoped<IClient, Client>();
builder.Services.ConfigureServices();

builder.Services.AddHttpClient<IClient, Client>(client => client.BaseAddress = new Uri("https://localhost:5001"));

await builder.Build().RunAsync();
