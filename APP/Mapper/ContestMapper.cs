using APP.Dto.ContestDto;
using AutoMapper;
using DOMAIN.model;

namespace APP.Mapper;


public class ContestMapper : Profile
{
    public ContestMapper()
    {
        // Crud
        CreateMap<CreateContestDto, Contest>();
        CreateMap<UpdateContestDto, Contest>();

        // Query
        CreateMap<Contest, GetContestDto>();
    }
}