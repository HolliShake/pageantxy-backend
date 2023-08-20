

using APP.Dto.ScoreDto;
using AutoMapper;
using DOMAIN.model;

namespace APP.Mapper;

public class ScoreMapper : Profile
{
    public ScoreMapper()
    {
        // Crud
        CreateMap<CreateScoreDto, Score>();
        CreateMap<UpdateScoreDto, Score>();

        // Query
        CreateMap<Score, GetScoreDto>();
    }
}