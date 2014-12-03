using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.WeatherStation
{
    public interface ISubject
    {
        void registerObserver(IObserver o);
        void removeObserver(IObserver o);
        void notifyObservers();
    }

    public class WeatherData : ISubject
    {
        private IList<IObserver> observers;
        private float temperature;
        private float humidity;
        private float pressure;

        public  WeatherData()
        {
            observers = new List<IObserver>();
        }

        public void registerObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void removeObserver(IObserver o)
        {
            int i = observers.IndexOf(o);
            if (i >= 0)
            {
                observers.RemoveAt(i);
            }
        }

        public void notifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.update(temperature, humidity, pressure);
            }

        }

        public void measurementsChanged() { notifyObservers(); }

        public void setMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            measurementsChanged();
        }
    }
}
