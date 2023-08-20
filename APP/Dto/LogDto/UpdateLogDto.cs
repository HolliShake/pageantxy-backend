

namespace APP.Dto.LogDto;

public class UpdateLogDto
{
    // Foreign key for user
    public string UserId { get; set; }

    // Foreign key for contest
    public int ContestId { get; set; }
}