

using DOMAIN.model;

namespace APP.Dto.RegisterDto;

public class CreateRegisterDto
{
    // Foreign key for candidate
    public int CandidateId { get; set; }

    // Foreign key for contest
    public int ContestId { get; set; }
}