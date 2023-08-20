
using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN.model;
public class Score : GenericModel
{
    // Foreign key for judge/user
    [ForeignKey("Judge")]
    public string JudgeId { get; set; }
    public User Judge { get; set; }

    // Foreignkey for contest
    public int ContestId { get; set; }
    public Contest Contest { get; set; }

    // Foreignkey for candidate
    public int CandidateId { get; set; }
    public Candidate Candidate { get; set; }

    public double ScoreValue { get; set; }
}