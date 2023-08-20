
using APP.Dto.RegisterDto;
using APP.IServices;
using AutoMapper;
using DOMAIN.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class RegisterController : GenericController<IRegisterService, Register>
{
    private readonly IContestService _contestRepo;
    private readonly ICandidateService _candidateRepo;

    public RegisterController(IMapper mapper, IContestService contestRepo, ICandidateService candidateRepo, IRegisterService repo) : base(mapper, repo)
    {
        _contestRepo = contestRepo;
        _candidateRepo = candidateRepo;
    }

    // Get All
    [HttpGet("all", Name = "GetAllRegister")]
    public async Task<ActionResult> GetAllRegister()
    {
        return await GenericGetAll<GetRegisterDto>();
    }

    // Get by id
    [HttpGet("{id:int}", Name = "GetRegister")]
    public async Task<ActionResult> GetRegister(int id)
    {
        return await GenericGet<GetRegisterDto>(id);
    }

    // Create
    [HttpPost("create", Name = "CreateRegister")]
    public async Task<ActionResult> CreateRegister(CreateRegisterDto createRegisterDto)
    {
        var newEntry = _mapper.Map<Register>(createRegisterDto);
        newEntry.Contest = await _contestRepo.GetAsync(newEntry.ContestId);
        newEntry.Candidate = await _candidateRepo.GetAsync(newEntry.CandidateId);

        return (await _repo.CreateAsync(newEntry))
            ? Ok(newEntry)
            : BadRequest("Something went wrong!");
    }

    // Update
    [HttpPut("update/{id:int}", Name = "UpdateRegister")]
    public async Task<ActionResult> UpdateRegister(int id, [FromBody] UpdateRegisterDto updateRegisterDto)
    {
        return await GenericUpdate(id, updateRegisterDto);
    }

    // Delete
    [HttpDelete("delete/{id:int}", Name = "DeleteRegister")]
    public async Task<ActionResult> DeleteRegister(int id)
    {
        return await GenericDelete(id);
    }
}