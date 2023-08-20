
using APP.Dto.EventDto;
using AutoMapper;
using DOMAIN.model;

namespace APP.Mapper;

public class EventMapper : Profile
{
    public EventMapper()
    {
        // Crud
        CreateMap<CreateEventDto, Event>();
        CreateMap<UpdateEventDto, Event>();

        // Query
        CreateMap<Event, GetEventDto>();
    }
}