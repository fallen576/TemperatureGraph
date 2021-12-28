using ArduinoSite.Models;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ArduinoSite.Hubs
{
    public static class MessageSender
    {
        public static Queue<Temperature> _tempQueue = new();

        public static void Enqueue(Temperature temp)
        {
            _tempQueue.Enqueue(temp);
            Console.WriteLine("Adding to queue " + temp);
        }

    }
}
