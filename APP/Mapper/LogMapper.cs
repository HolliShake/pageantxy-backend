

using APP.Dto.LogDto;
using AutoMapper;
using DOMAIN.model;

namespace APP.Mapper;
public class LogMapper : Profile
{
    public LogMapper()
    {
        // Crud
        CreateMap<CreateLogDto, Log>();
        CreateMap<UpdateLogDto, Log>();

        // Query
        CreateMap<Log, GetLogDto>();
    }
}