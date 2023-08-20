using APP.Dto.CandidateDto;
using AutoMapper;
using DOMAIN.model;

namespace APP.Mapper;
public class CandidateMapper : Profile
{
    public CandidateMapper()
    {
        // Crud
        CreateMap<CreateCandidateDto, Candidate>();
        CreateMap<UpdateCandidateDto, Candidate>();

        // Query
        CreateMap<Candidate, GetCandidateDto>();
    }
}