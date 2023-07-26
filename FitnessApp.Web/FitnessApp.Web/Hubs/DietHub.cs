using FitnessApp.Web.ViewModels.Models.Diet;
using Microsoft.AspNetCore.SignalR;

namespace FitnessApp.Web.Hubs
{
    public class DietHub : Hub
    {
        public async Task SendMessage(DietsResultModel model)
        {
            await Clients.All.SendAsync("ReceiveMessage", model);
        }
    }
}
