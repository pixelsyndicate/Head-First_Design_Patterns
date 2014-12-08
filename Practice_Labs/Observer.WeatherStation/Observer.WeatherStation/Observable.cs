using System;

namespace Observer.WeatherStation
{
    public abstract class Observable
    {
        public event EventHandler SomethingHappened;

        public virtual void NoteSomethingHappened(string whatHappened)
        {
            EventHandler handler = SomethingHappened;
            if (handler != null)
            {
                var ea = new WeatherEventArgs
                {
                    Description = whatHappened
                };
                handler(this, ea);
            }
        }

    }
}