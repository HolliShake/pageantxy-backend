﻿

using APP.Dto.EventDto;
using DOMAIN.model;

namespace APP.Dto.ContestDto;

public class GetContestDto
{
    public int Id { get; set; }
    public string ContestName { get; set; }
    public string ContestDescription { get; set; }
    public int ContestOrder { get; set; }
    public double Weight { get; set; }
    public int InputMin { get; set; }
    public int InputMax { get; set; }
    // Foreign key for event
    public int EventId { get; set; }
    public GetEventDto Event { get; set; }
    public bool IsLocked { get; set; }
    public bool IsActive { get; set; }
}