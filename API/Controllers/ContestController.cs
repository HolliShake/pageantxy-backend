using APP.Dto.ContestDto;
using APP.IServices;
using AutoMapper;
using CQI.INFRA.Hubs;
using DOMAIN.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ContestController : GenericController<IContestService, Contest>
{
    private readonly IHubContext<ContestHub> _contestHub;

    public ContestController(IMapper mapper, IHubContext<ContestHub> contestHub, IContestService repo) : base(mapper, repo)
    {
        _contestHub = contestHub;
    }

    // Get All
    [HttpGet("all", Name = "GetAllContest")]
    public async Task<ActionResult> GetAllContest()
    {
        return await GenericGetAll<GetContestDto>();
    }

    // Get by id
    [HttpGet("{id:int}", Name = "GetContest")]
    public async Task<ActionResult> GetContest(int id)
    {
        return await GenericGet<GetContestDto>(id);
    }

    // Create
    [HttpPost("create", Name = "CreateContest")]
    public async Task<ActionResult> CreateContest([FromBody] CreateContestDto createBody)
    {
        return await GenericCreate(createBody);
    }

    // Update
    [HttpPut("update/{id:int}", Name = "UpdateContest")]
    public async Task<ActionResult> UpdateContest(int id, [FromBody] UpdateContestDto updateBody)
    {
        var existingRecord = await _repo.GetAsync(id);

        if (existingRecord == null)
        {
            return NotFound();
        }

        var updatedEntry = _mapper.Map(updateBody, existingRecord);
        var name = this.GetType().Name.Replace("Controller", "");

        var result = await _repo.UpdateAsync(updatedEntry);

        if (result)
        {
            await _contestHub.Clients.Group("judges").SendAsync("RecievedUpdate", _mapper.Map<GetContestDto>(existingRecord));
        }

        return (result)
            ? NoContent()
            : BadRequest($"Could not update {name} with id {id}!");
    }

    // Delete
    [HttpDelete("delete/{id:int}", Name = "DeleteContest")]
    public async Task<ActionResult> DeleteContest(int id)
    {
        return await GenericDelete(id);
    }
}