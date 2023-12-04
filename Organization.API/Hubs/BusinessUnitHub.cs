using Microsoft.AspNetCore.SignalR;
using Organization.API.Hubs.Notifiers;

namespace Organization.API.Hubs
{
    public class BusinessUnitHub : Hub
    {
        public async Task NotifyMove(BusinessUnitNotifier notifier)
        {
            await Clients.All.SendAsync("UpdateBusiness", notifier);
        }
    }
}
