using APP.Dto.AuthDto;
using APP.Dto.UserDto;
using AutoMapper;
using DOMAIN.model;

namespace APP.Mapper;


public class AuthMapper : Profile
{
    public AuthMapper()
    {
        // Crud
        CreateMap<RegisterDto, User>();
        CreateMap<RegisterDto, CreateUserDto>();
    }
}