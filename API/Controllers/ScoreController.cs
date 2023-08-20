using APP.Dto.ScoreDto;
using APP.IServices;
using AutoMapper;
using DOMAIN.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]

public class ScoreController : GenericController<IScoreService, Score>
{
    private readonly IContestService _contestRepo;
    private ICandidateService _candidateRepo;

    public ScoreController(IMapper mapper, IContestService contestRepo, ICandidateService candidateRepo, IScoreService repo) : base(mapper, repo)
    {
        _contestRepo = contestRepo;
        _candidateRepo = candidateRepo;
    }

    // Get All
    [HttpGet("all", Name = "GetAllScore")]
    public async Task<ActionResult> GetAllScore()
    {
        return await GenericGetAll<GetScoreDto>();
    }

    // Get All By Candidate Id
    [HttpGet("all/groupByCandidate", Name = "GetAllScoreGroupByCandidate")]
    public async Task<ActionResult> GetAllScoreGroupByCandidate()
    {
        return Ok(await _repo.GetAllScoreGroupByCandidateId());
    }

    // Get All
    [HttpGet("all/byJudgeId/{id}", Name = "GetAllScoreByJudgeId")]
    public async Task<ActionResult> GetAllScoreByJudgeId(string id)
    {
        return Ok(_mapper.Map<ICollection<GetScoreDto>>(await _repo.GetAllByJudgeId(id)));
    }

    // Get by id
    [HttpGet("{id:int}", Name = "GetScore")]
    public async Task<ActionResult> GetScore(int id)
    {
        return await GenericGet<GetScoreDto>(id);
    }

    // Create
    [HttpPost("create", Name = "CreateScore")]
    public async Task<ActionResult> CreateScore([FromBody] CreateScoreDto createBody)
    {
        var newEntry = _mapper.Map<Score>(createBody);
        newEntry.Candidate = await _candidateRepo.GetAsync(newEntry.CandidateId);
        newEntry.Contest = await _contestRepo.GetAsync(newEntry.ContestId);

        return (await _repo.CreateAsync(newEntry))
            ? Ok(newEntry)
            : BadRequest("Something went wrong!");
    }

    // Update
    [HttpPut("update/{id:int}", Name = "UpdateScore")]
    public async Task<ActionResult> UpdateScore(int id, [FromBody] UpdateScoreDto updateBody)
    {
        return await GenericUpdate(id, updateBody);
    }

    // Delete
    [HttpDelete("delete/{id:int}", Name = "DeleteScore")]
    public async Task<ActionResult> DeleteScore(int id)
    {
        return await GenericDelete(id);
    }
}