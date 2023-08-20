

using APP.Dto.ContestDto;
using APP.Dto.UserDto;

namespace APP.Dto.LogDto;
public class GetLogDto
{
    public int Id { get; set; }

    // Foreign key for user
    public string UserId { get; set; }
    public GetUserDto User { get; set; }

    // Foreign key for contest
    public int ContestId { get; set; }
    public GetContestDto Contest { get; set; }

    public DateTime LogDate { get; set; }
}