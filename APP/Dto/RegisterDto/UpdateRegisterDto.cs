
namespace APP.Dto.RegisterDto;
public class UpdateRegisterDto
{
    // Foreign key for candidate
    public int CandidateId { get; set; }

    // Foreign key for contest
    public int ContestId { get; set; }
}