using ChampWebApp.Abstractions.Repositories;
using ChampWebApp.GraphQl.Filters;
using ChampWebApp.GraphQl.Sortes;
using ChampWebApp.Models;

namespace ChampWebApp.GraphQl.Queries;

public class CommandQuery
{
    [UsePaging(typeof(Command))]
    [UseSorting(typeof(CommandSort))]
    [UseFiltering(typeof(CommandFilter))]
    public async Task<IEnumerable<Command>> GetCommandsAsync([Service] IUnitOfWorkRepository repos)
    {
        return await repos.GenericRepository<Command>().GetAsync(includeProperties:"Coach,Country");
    }
}