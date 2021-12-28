using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using ArduinoSite.Models;
using System;

namespace ArduinoSite.Hubs
{
    
    public interface IClientInteraction
    {
        Task ClientHook(Temperature temperature);
    }
    public class CustomHub : Hub<IClientInteraction>
    {
        public async Task UpdateTemperature(Temperature temperature) {
            Console.WriteLine("executing sockets " + temperature);
            await Clients.All.ClientHook(temperature);
        }
    }
    
    /*
    public class CustomHub : Hub
    {
        public async Task UpdateTemperature(Temperature temperature)
        {
            Console.WriteLine("executing sockets " + temperature);
            await Clients.All.SendAsync("update_temperature",temperature);
        }
    }
    */
}