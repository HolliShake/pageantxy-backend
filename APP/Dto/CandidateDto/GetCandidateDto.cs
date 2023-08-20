

using APP.Dto.EventDto;
using DOMAIN.model;

namespace APP.Dto.CandidateDto;

public class GetCandidateDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }

    public int CandidateNumber { get; set; }
    public string Group { get; set; }
    public string Representation { get; set; }
    public string Picture { get; set; }
}