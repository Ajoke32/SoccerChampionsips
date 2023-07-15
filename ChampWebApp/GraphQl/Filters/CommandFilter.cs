using ChampWebApp.Models;
using HotChocolate.Data.Filters;

namespace ChampWebApp.GraphQl.Filters;

public class CommandFilter:FilterInputType<Command>
{
    protected override void Configure(IFilterInputTypeDescriptor<Command> descriptor)
    {
        descriptor.Field(c => c.Country.Name).Name("country_name");
        descriptor.Field(c => c.Coach.FirstName).Name("coach_name");
    }
}