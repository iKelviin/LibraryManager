using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using LibraryManager.Site;
using LibraryManager.Site.Repositories;
using LibraryManager.Site.Repositories.Interfaces;
using LibraryManager.Site.Security;
using LibraryManager.Site.Services;
using LibraryManager.Site.Services.Interfaces;
using LibraryManager.Site.Shared;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("API", client =>
    {
        client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress); // Defina a URL base para a API
    })
    .AddHttpMessageHandler<JwtAuthenticationHandler>(); // Adiciona o JwtAuthenticationHandler ao pipeline de requisições

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<ILoanRepository, LoanRepository>();

// Auth Services
builder.Services.AddScoped<CookieService>();
builder.Services.AddScoped<CustomAuthenticationStateProvider>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<CascadingAuthenticationState>();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<JwtAuthenticationHandler>();

// Shared JS Components
builder.Services.AddScoped<Toastify>();
builder.Services.AddScoped<SweetAlert>();

await builder.Build().RunAsync();