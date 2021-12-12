using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ArduinoSite.Models;

namespace ArduinoSite.Hubs
{
    public interface IClientInteraction
    {
        Task ClientHook(Temperature temperature);
    }
    public class CustomHub : Hub<IClientInteraction>
    {
        public async Task UpdateTemperature(Temperature temperature) {
            await Clients.All.ClientHook(temperature);
        }
    }
}