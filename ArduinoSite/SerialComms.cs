namespace ArduinoSite
{
    using ArduinoSite.Hubs;
    using ArduinoSite.Models;
    using Microsoft.AspNet.SignalR;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Collections.Generic;
    using System.IO.Ports;
    using System.Threading;
    using System.Threading.Tasks;

    public class SerialComms
    {
        private static SerialPort _port = new SerialPort();
        public static void Init()
        {

            _port.BaudRate = 9600;
            _port.PortName = "COM3";
            Console.WriteLine(_port.PortName + " " + _port.IsOpen);
            _port.Open();
            Console.WriteLine(_port.PortName + " " + _port.IsOpen);
            _port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
        }

        private static void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                SerialPort sp = (SerialPort)sender;
                string indata = sp.ReadLine();
                var data = indata.Split(",");
                var voltage = data[0].Split(": ")[1];
                var degc = data[1].Split(": ")[1];
                var degf = data[2].Split(": ")[1];
                //Console.WriteLine($"Voltage: {voltage} Celcius: {degc} Fahrenheit {degf}");
                Temperature temp = new Temperature()
                {
                    Celcius = Double.Parse(degc),
                    Fahrenheit = Double.Parse(degf),
                    Voltage = Double.Parse(voltage)
                };
                //cant do anything cause this is a static method
                MessageSender.Enqueue(temp);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message );
            }
        }
        
        public static void PrintPorts()
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                Console.WriteLine("Port: " + s);
            }
        }
    }
}
