using AutoMapper;
using AutoMapper.QueryableExtensions;
using ChampWebApp.Abstractions.Repositories;
using ChampWebApp.Models;
using ChampWebApp.Models.Dtos.Display;

namespace ChampWebApp.GraphQl.Queries;

public class UserQuery
{
    private readonly IUnitOfWorkRepository _uof;
    private readonly IMapper _mapper;
    public UserQuery(IUnitOfWorkRepository uof, IMapper mapper)
    {
        _uof = uof;
        _mapper = mapper;
    }
    
    [UseFiltering]
    public async Task<IEnumerable<UserDisplayDto>> GetUsers()
    {
        var users = await _uof.GenericRepository<User>().GetAsync(includeProperties: "Role");
        return _mapper.Map<IEnumerable<User>,IEnumerable<UserDisplayDto>>(users);
    }
}