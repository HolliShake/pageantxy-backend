

using APP.Dto.CandidateDto;
using APP.Dto.ContestDto;
using APP.Dto.UserDto;
using DOMAIN.model;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP.Dto.ScoreDto;
public class GetScoreDto
{
    public int Id { get; set; }
    // Foreign key for judge/user
    [ForeignKey("Judge")]
    public string JudgeId { get; set; }
    public GetUserDto Judge { get; set; }

    // Foreignkey for contest
    public int ContestId { get; set; }
    public GetContestDto Contest { get; set; }

    // Foreignkey for candidate
    public int CandidateId { get; set; }
    public GetCandidateDto Candidate { get; set; }

    public double ScoreValue { get; set; }
}