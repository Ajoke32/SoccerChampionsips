using ChampWebApp.Models;
using HotChocolate.Data.Sorting;

namespace ChampWebApp.GraphQl.Sortes;

public class CommandSort:SortInputType<Command>
{
    protected override void Configure(ISortInputTypeDescriptor<Command> descriptor)
    {
        descriptor.Field(c => c.Country.Name).Name("country_name");
        
        descriptor.Field(c => c.Coach.FirstName)
            .Name("coach_name");
    }
}