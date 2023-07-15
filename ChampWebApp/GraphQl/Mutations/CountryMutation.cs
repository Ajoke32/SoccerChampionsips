using ChampWebApp.Abstractions.Repositories;
using ChampWebApp.Models;

namespace ChampWebApp.GraphQl.Mutations;

public class CountryMutation
{
    public async Task<Country> CreateCountry([Service] IUnitOfWorkRepository repo,string name)
    {
        return await repo.GenericRepository<Country>().CreateAsync(new Country()
        {
            Name = name
        });
    }
}