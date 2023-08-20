using APP.Dto.CandidateDto;
using APP.Dto.ContestDto;

namespace APP.Dto.RegisterDto;

public class GetRegisterDto
{
    public int Id { get; set; }
    // Foreign key for candidate
    public int CandidateId { get; set; }
    public GetCandidateDto Candidate { get; set; }

    // Foreign key for contest
    public int ContestId { get; set; }
    public GetContestDto Contest { get; set; }
}