using Microsoft.AspNetCore.SignalR;
using Organization.API.Controllers;

namespace Organization.API.Hubs
{
    public class ValueHub : Hub
    {
        public async Task NotifyValueChange(ValueModel model)
        {
            await Clients.All.SendAsync("UpdateValue", model);
        }
    }
}