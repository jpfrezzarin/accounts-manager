using AccountsManager.Domain.Accounts;
using AccountsManager.Infrastructure.Accounts.Models;
using AutoMapper;

namespace AccountsManager.Infrastructure.Common;

public class AccountsManagerMappingProfile : Profile
{
    public AccountsManagerMappingProfile()
    {
        CreateMap<Account, AccountDao>().ReverseMap()
            .ForCtorParam("balance", o => o.MapFrom(_ => 0));
        CreateMap<Transaction, TransactionDao>().ReverseMap();
    }
}