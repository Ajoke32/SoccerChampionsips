using AutoMapper;
using ChampWebApp.Abstractions.Repositories;

namespace ChampWebApp.GraphQl.Queries;

public class RootQuery:ObjectType
{

    
    protected override void Configure(IObjectTypeDescriptor descriptor)
    {
        descriptor.Field("coachQuery")
            .Resolve(_ => new CoachQuery());

        descriptor.Field("userQuery")
            .Resolve(_ => new UserQuery());

        descriptor.Field("commandQuery")
            .Resolve(_ => new CommandQuery());
        
        descriptor.Field("champQuery")
            .Resolve(_ => new ChampsQuery());
    }
}