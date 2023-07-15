using ChampWebApp.Abstractions.Repositories;
using ChampWebApp.Models;

namespace ChampWebApp.GraphQl.Mutations;

public class ChampsMutation
{
    public async Task<Tournament> CreateTournament([Service] IUnitOfWorkRepository repo,string name)
    {
        return await repo.GenericRepository<Tournament>().CreateAsync(new Tournament()
        {
            Name = name
        });
    }
}