using ChampWebApp.Abstractions.Repositories;
using ChampWebApp.Models;

namespace ChampWebApp.GraphQl.Queries;

public class ChampsQuery
{
    [UseFiltering]
    public async Task<IEnumerable<Tournament>> GetChampsAsync([Service] IUnitOfWorkRepository uof)
    {
        return await uof.GenericRepository<Tournament>().GetAsync();
    }
}