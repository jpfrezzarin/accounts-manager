using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AccountsManager.Api.Commons;

/// <summary>
/// Class to order the json properties prioritizing the base classes 
/// </summary>
public class BaseClassJsonContractResolver : DefaultContractResolver
{
    public BaseClassJsonContractResolver()
    {
        NamingStrategy = new CamelCaseNamingStrategy();
    }

    protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
    {
        return [.. base.CreateProperties(type, memberSerialization).OrderBy(p => BaseTypesAndSelf(p.DeclaringType).Count())];

        static IEnumerable<Type> BaseTypesAndSelf(Type? t)
        {
            while (t != null) 
            {
                yield return t;
                t = t.BaseType;
            }
        }
    }
}