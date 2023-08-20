
using System.ComponentModel.DataAnnotations;

namespace DOMAIN.model;
public class Log
{
    [Key]
    public int Id { get; set; }

    // Foreign key for user
    public string UserId { get; set; }
    public User User { get; set; }

    // Foreign key for contest
    public int ContestId { get; set; }
    public Contest Contest { get; set; }

    public DateTime LogDate { get; set; } = DateTime.Now;
}