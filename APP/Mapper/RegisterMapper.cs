

using APP.Dto.RegisterDto;
using AutoMapper;
using DOMAIN.model;

namespace APP.Mapper;

public class RegisterMapper : Profile
{
    public RegisterMapper()
    {
        // Crud
        CreateMap<CreateRegisterDto, Register>();
        CreateMap<UpdateRegisterDto, Register>();

        // Query
        CreateMap<Register, GetRegisterDto>();
    }
}