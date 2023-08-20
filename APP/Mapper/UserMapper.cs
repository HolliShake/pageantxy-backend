

using APP.Dto.UserDto;
using AutoMapper;
using DOMAIN.model;

namespace APP.Mapper;

public class UserMapper : Profile
{
    public UserMapper()
    {
        // Crud
        CreateMap<CreateUserDto, User>();
        CreateMap<UpdateUserDto, User>();
        CreateMap<VerifyUserDto, User>();

        // Query
        CreateMap<User, GetUserDto>();
    }
}