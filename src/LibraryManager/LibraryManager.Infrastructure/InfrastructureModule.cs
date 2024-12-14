using LibraryManager.Core.Repositories;
using LibraryManager.Core.Services;
using LibraryManager.Infrastructure.Persistence;
using LibraryManager.Infrastructure.Persistence.Repositories;
using LibraryManager.Infrastructure.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddRepositories()
            .AddData(configuration);
        return services;
    }

    public static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("LibraryManagerCS");
        services.AddDbContext<LibraryManagerDbContext>(o => o.UseSqlServer(connectionString, 
            b => b.MigrationsAssembly(typeof(LibraryManagerDbContext).Assembly.FullName)));
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ILoanRepository, LoanRepository>();
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
    
}