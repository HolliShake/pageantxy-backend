
namespace DOMAIN.model;
public class Register : GenericModel
{
    // Foreign key for candidate
    public int CandidateId { get; set; }
    public Candidate Candidate { get; set; }

    // Foreign key for contest
    public int ContestId { get; set; }
    public Contest Contest { get; set; }
}