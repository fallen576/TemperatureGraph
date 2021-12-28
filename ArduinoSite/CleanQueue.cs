using ArduinoSite.Hubs;
using ArduinoSite.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ArduinoSite
{
    public class CleanQueue : IHostedService, IDisposable
    {

        private Timer _timer = null;
        private readonly IHubContext<CustomHub, IClientInteraction> _customHub;
        //private readonly CustomHub _customHub;

        public CleanQueue(IHubContext<CustomHub, IClientInteraction> customHub)
        {
            _customHub = customHub;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(Execute, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));
            return Task.CompletedTask;
        }

        private async void Execute(object state)
        {
            if (MessageSender._tempQueue.Count > 0)
            {
                Temperature temp = MessageSender._tempQueue.Dequeue();
                Console.WriteLine("Leaving Queue " + temp);
                await _customHub.Clients.All.ClientHook(temp);
                //_customHub.Clients.All.UpdateTemperature(temp);
            }
            else
            {
                Console.WriteLine("Queue empty");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

    }
}
