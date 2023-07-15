using ChampWebApp.Abstractions.Repositories;
using ChampWebApp.Models;

namespace ChampWebApp.GraphQl.Queries;


public class CoachQuery
{

    [UsePaging(typeof(Coach))]
    [UseFiltering]
    public async Task<IEnumerable<Coach>> GetCoachesAsync([Service] IUnitOfWorkRepository uof)
    {
        return await uof.GenericRepository<Coach>().GetAsync();
    }

    public async Task<Coach?> GetCoach([Service] IUnitOfWorkRepository uof,int id)
    {
        return await uof.GenericRepository<Coach>().FindAsync(c => c.Id == id);
    }
}