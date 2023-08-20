



namespace APP.Dto.LogDto;

public class CreateLogDto
{
    // Foreign key for user
    public string UserId { get; set; }

    // Foreign key for contest
    public int ContestId { get; set; }
}