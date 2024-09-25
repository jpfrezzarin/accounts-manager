using AccountsManager.Application.Accounts;
using AccountsManager.Application.Accounts.ViewModels;
using AccountsManager.Domain.Accounts.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AccountsManager.Application.Common;

public static class DependecyInjection
{
    public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
    {
        services.AddScoped<IGetAccountByIdUseCase<AccountViewModel>, GetAccountByIdUseCase>();
        services.AddScoped<IGetAllAccountsUseCase<AccountOnlyViewModel>, GetAllAccountsUseCase>();
        services.AddScoped<ICreateAccountUseCase, CreateAccountUseCase>();
        services.AddScoped<ICreateTransactionUseCase, CreateTransactionUseCase>();
        services.AddScoped<IDeleteTransactionUseCase, DeleteTransactionUseCase>();
        
        return services;
    }
}