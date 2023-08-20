using APP.Dto.CandidateDto;
using APP.IServices;
using AutoMapper;
using DOMAIN.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class CandidateController : GenericController<ICandidateService, Candidate>
{
    public CandidateController(IMapper mapper, ICandidateService repo) : base(mapper, repo)
    {
    }

    // Get All
    [HttpGet("all", Name = "GetAllCandidate")]
    public async Task<ActionResult> GetAllCandidate()
    {
        return await GenericGetAll<GetCandidateDto>();
    }

    // Get by id
    [HttpGet("{id:int}", Name = "GetCandidate")]
    public async Task<ActionResult> GetCandidate(int id)
    {
        return await GenericGet<GetCandidateDto>(id);
    }

    // Create
    [HttpPost("create", Name = "CreateCandidate")]
    public async Task<ActionResult> CreateCandidate([FromBody] CreateCandidateDto createBody)
    {
        return await GenericCreate(createBody);
    }

    // Update
    [HttpPut("update/{id:int}", Name = "UpdateCandidate")]
    public async Task<ActionResult> UpdateCandidate(int id, [FromBody] UpdateCandidateDto updateBody)
    {
        return await GenericUpdate(id, updateBody);
    }

    // Delete
    [HttpDelete("delete/{id:int}", Name = "DeleteCandidate")]
    public async Task<ActionResult> DeleteCandidate(int id)
    {
        return await GenericDelete(id);
    }
}