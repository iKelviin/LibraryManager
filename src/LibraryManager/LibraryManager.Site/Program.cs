using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LibraryManager.Site;
using LibraryManager.Site.Repositories;
using LibraryManager.Site.Repositories.Interfaces;
using LibraryManager.Site.Services;
using LibraryManager.Site.Services.Interfaces;
using LibraryManager.Site.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

// Shared JS Components
builder.Services.AddScoped<Toastify>();
builder.Services.AddScoped<SweetAlert>();

await builder.Build().RunAsync();