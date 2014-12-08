using System;

namespace Observer.WeatherStation
{
    public abstract class ObserverBase
    {
        public virtual void DisplayLog(object sender, WeatherEventArgs eventArgs)
        {
            Console.WriteLine("LOG:" + eventArgs.Description + " ~ by " + sender);
        }
    }
}