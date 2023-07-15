using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChampWebApp.Abstractions.Repositories;
using ChampWebApp.Models;
using ChampWebApp.Models.Dtos.Display;

namespace ChampWebApp.GraphQl.Queries;


public class UserQuery
{
 
    [UseFiltering]
    public async Task<IEnumerable<UserDisplayDto>> GetUsers([Service] IUnitOfWorkRepository uof,[Service] IMapper mapper)
    {
        var users = await uof.GenericRepository<User>().GetAsync(includeProperties: "Role");
        return mapper.Map<IEnumerable<User>,IEnumerable<UserDisplayDto>>(users);
    }
 
}