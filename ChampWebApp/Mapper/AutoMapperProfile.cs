using AutoMapper;
using ChampWebApp.Models;
using ChampWebApp.Models.Dtos;

namespace ChampWebApp.Mapper;

public class AutoMapperProfile:Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserRegisterDto>();
        CreateMap<UserRegisterDto, User>()
            .ForMember(u=>u.PasswordHash,
                opt=>opt.MapFrom(u=>u.Password));
    }
}