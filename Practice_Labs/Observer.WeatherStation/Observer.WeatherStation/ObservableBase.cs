using System;

namespace Observer.WeatherStation
{
    public abstract class ObservableBase
    {
        public event EventHandler<WeatherEventArgs> LogEvent;

        public virtual void NoteSomethingHappened(string whatHappened)
        {
            EventHandler<WeatherEventArgs> handler = LogEvent;
            if (handler == null) return;
            handler(this, new WeatherEventArgs { Description = whatHappened });
        }

    }


}