using APP.Dto.ContestDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Collections.ObjectModel;

namespace CQI.INFRA.Hubs;

[Authorize]
public class ContestHub : Hub
{
    public async Task UpdateContest(GetContestDto contest)
    {
        await Clients.Group("judges").SendAsync("RecievedUpdate", contest);
    }

    public override Task OnConnectedAsync()
    {
        Groups.AddToGroupAsync(Context.ConnectionId, "judges");

        return base.OnConnectedAsync();
    }

}

public class KeyValuePair
{
    public string ConnId { get; set; }
    public string User { get; set; }
}