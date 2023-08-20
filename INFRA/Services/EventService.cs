
using APP.IServices;
using DOMAIN.model;
using INFRA.Data;

namespace INFRA.Services;

public class EventService : GenericService<Event>, IEventService
{
    public EventService(AppDbContext context) : base(context)
    {
    }
}