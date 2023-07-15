using ChampWebApp.Models;

namespace ChampWebApp.GraphQl.Mutations;

public class RootMutation:ObjectType
{
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Field("countryMutation")
            .Resolve(_ => new CountryMutation());

        descriptor.Field("champMutation")
            .Resolve(_ => new ChampsMutation());
    }
}