using AccountsManager.Infrastructure.Common;
using AutoMapper;

namespace AccountsManager.Infrastructure.Tests.Fixtures;

public class MappingProfileFixture
{
    public IMapper Mapper { get; private set; }

    public MappingProfileFixture()
    {
        var mapperConfig = new MapperConfiguration(config =>
        {
            config.AddProfile(new AccountsManagerMappingProfile());
        });

        Mapper = mapperConfig.CreateMapper();
    }
}