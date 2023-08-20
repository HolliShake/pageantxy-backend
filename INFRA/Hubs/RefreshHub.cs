using APP.Dto.ContestDto;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INFRA.Hubs;

public class RefreshHub : Hub
{
    public async Task RefreshPage()
    {
        await Clients.Group("judges").SendAsync("RefreshPage");
    }

    public override Task OnConnectedAsync()
    {
        Groups.AddToGroupAsync(Context.ConnectionId, "judges");

        return base.OnConnectedAsync();
    }
}