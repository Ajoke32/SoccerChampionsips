using AutoMapper;
using ChampWebApp.Models;
using ChampWebApp.Models.Dtos;
using ChampWebApp.Models.Dtos.Display;
using ChampWebApp.Models.Dtos.Input;

namespace ChampWebApp.Mapper;

public class AutoMapperProfile:Profile
{
    public AutoMapperProfile()
    {
        CreateMap<User, UserRegisterDto>();
        CreateMap<User, UserDisplayDto>();
        CreateMap<UserRegisterDto, User>()
            .ForMember(u=>u.PasswordHash,
                opt=>
                    opt.MapFrom(u=>u.Password));

        CreateMap<CommandInputDto, Command>();

    }
}