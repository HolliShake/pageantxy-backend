using APP.IServices;
using AutoMapper;
using DOMAIN.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using APP.Dto.EventDto;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EventController : GenericController<IEventService, Event>
{
    public EventController(IMapper mapper, IEventService repo) : base(mapper, repo)
    {
    }

    // Get All
    [HttpGet("all", Name = "GetAllEvent")]
    public async Task<ActionResult> GetAllEvent()
    {
        return await GenericGetAll<GetEventDto>();
    }

    // Get by id
    [HttpGet("{id:int}", Name = "GetEvent")]
    public async Task<ActionResult> GetEvent(int id)
    {
        return await GenericGet<GetEventDto>(id);
    }

    // Create
    [HttpPost("create", Name = "CreateEvent")]
    public async Task<ActionResult> CreateEvent([FromBody] CreateEventDto createBody)
    {
        return await GenericCreate(createBody);
    }

    // Update
    [HttpPut("update/{id:int}", Name = "UpdateEvent")]
    public async Task<ActionResult> UpdateEvent(int id, [FromBody] UpdateEventDto updateBody)
    {
        return await GenericUpdate(id, updateBody);
    }

    // Delete
    [HttpDelete("delete/{id:int}", Name = "DeleteEvent")]
    public async Task<ActionResult> DeleteEvent(int id)
    {
        return await GenericDelete(id);
    }
}
