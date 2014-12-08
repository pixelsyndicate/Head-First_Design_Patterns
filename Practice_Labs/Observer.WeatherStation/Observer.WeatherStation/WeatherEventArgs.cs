using System;

namespace Observer.WeatherStation
{
    public class WeatherEventArgs : EventArgs
    {
        public string Description { get; set; }
    }
}