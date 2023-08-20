

using DOMAIN.model;
using System.ComponentModel.DataAnnotations.Schema;

namespace APP.Dto.ScoreDto;
public class CreateScoreDto
{
    // Foreign key for judge/user
    [ForeignKey("Judge")]
    public string JudgeId { get; set; }

    // Foreignkey for contest
    public int ContestId { get; set; }

    // Foreignkey for candidate
    public int CandidateId { get; set; }

    public double ScoreValue { get; set; }
}