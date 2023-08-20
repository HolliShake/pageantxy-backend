using APP.Dto.ContestDto;
using APP.Dto.LogDto;
using APP.Dto.ScoreDto;
using APP.IServices;
using AutoMapper;
using CQI.INFRA.Hubs;
using DOMAIN.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class LogController : GenericController<ILogService, Log>
{
    private readonly IHubContext<ContestHub> _contestHub;

    public LogController(IMapper mapper, IHubContext<ContestHub> contestHub, ILogService repo) : base(mapper, repo)
    {
        _contestHub = contestHub;
    }

    // Get All
    [HttpGet("all", Name = "GetAllLog")]
    public async Task<ActionResult> GetAllLog()
    {
        return await GenericGetAll<GetLogDto>();
    }

    // Get by id
    [HttpGet("{id:int}", Name = "GetLog")]
    public async Task<ActionResult> GetLog(int id)
    {
        return await GenericGet<GetLogDto>(id);
    }

    // Create
    [HttpPost("create", Name = "CreateLog")]
    public async Task<ActionResult> CreateLog([FromBody] CreateLogDto createBody)
    {
        return await GenericCreate(createBody);
    }

    // Update
    [HttpPut("update/{id:int}", Name = "UpdateLog")]
    public async Task<ActionResult> UpdateLog(int id, [FromBody] UpdateLogDto updateBody)
    {
        return await GenericUpdate(id, updateBody);
    }

    // Get All
    [HttpGet("all/byJudgeId/{id}", Name = "GetAllLogsByJudgeId")]
    public async Task<ActionResult> GetAllLogsByJudgeId(string id)
    {
        return Ok(_mapper.Map<ICollection<GetLogDto>>(await _repo.GetAllByJudgeId(id)));
    }

    // Delete
    [HttpDelete("delete/{id:int}", Name = "DeleteLog")]
    public async Task<ActionResult> DeleteLog(int id)
    {
        var existingRecord = await _repo.GetAsync(id);

        if (existingRecord == null)
        {
            return NotFound();
        }

        var name = this.GetType().Name.Replace("Controller", "");
        var result = await _repo.DeleteAsync(existingRecord);

        if (result)
        {
            await _contestHub.Clients.Group("judges").SendAsync("RecievedUpdate", _mapper.Map<GetContestDto>(existingRecord.Contest));
        }

        return (result)
            ? NoContent()
            : BadRequest($"Could not delete {name} with id {id}!");
    }
}