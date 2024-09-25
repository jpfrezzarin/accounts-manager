using System.Reflection;
using AccountsManager.Application.Accounts.Interfaces;
using AccountsManager.Infrastructure.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AccountsManager.Infrastructure.Common;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddDbContext<AccountContext>(o =>
        {
            o.UseSqlite(configuration.GetConnectionString("AccountsManager"));
        });

        services.AddScoped<IAccountRepository, AccountRepository>();
        
        return services;
    }
}