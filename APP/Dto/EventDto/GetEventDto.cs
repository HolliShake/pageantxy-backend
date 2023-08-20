

namespace APP.Dto.EventDto;
public class GetEventDto
{
    public int Id { get; set; }
    public string EventName { get; set; }
    public string EventDescription { get; set; }
    public string Sponsor { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public string Venue { get; set; }
}