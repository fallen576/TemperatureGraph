using System;

namespace ArduinoSite.Models
{
    public class Temperature
    {
        //"voltage: 0.73 deg C: 22.75 deg F: 72.96"
        public double Voltage { get; set; }
        public double Celcius { get; set; }
        public double Fahrenheit { get; set; }
    }
}
