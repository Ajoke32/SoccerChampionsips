using ChampWebApp.Abstractions.Repositories;
using ChampWebApp.Models;

namespace ChampWebApp.GraphQl.Resolvers;

public class CoachResolver
{
    private readonly IUnitOfWorkRepository _repos;

    public CoachResolver(IUnitOfWorkRepository rep)
    {
        _repos = rep;
    }

    public async Task<IEnumerable<Coach>> GetAllAsync()
    {
        return await _repos.GenericRepository<Coach>().GetAsync();
    }
}