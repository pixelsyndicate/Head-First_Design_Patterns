using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Observer.WeatherStation
{
    public class WeatherData : Observable, ISubject
    {
        private readonly IList<IObserver> observers;
        private float temperature;
        private float humidity;
        private float pressure;

        internal ObservableCollection<ISubject> knownSubjects;
        internal IObserver AnObserver;

        public WeatherData()
        {

            observers = new List<IObserver>();
            knownSubjects = new ObservableCollection<ISubject>();
        }

        public void registerObserver(IObserver o)
        {
            observers.Add(o);
            NoteSomethingHappened("Added Observer");
        }

        public void removeObserver(IObserver o)
        {
            int i = observers.IndexOf(o);
            if (i >= 0)
            {
                observers.RemoveAt(i);
                NoteSomethingHappened("Removed Observer");
            }
        }

        public void notifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.update(temperature, humidity, pressure);
                NoteSomethingHappened("Updated Temp, Humidity and Pressure");
            }
        }

        public void measurementsChanged()
        {
            notifyObservers();
            NoteSomethingHappened("Detected Changes.");
        }

        public void setMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            measurementsChanged();
            NoteSomethingHappened("Setting values of " + temperature.ToString() + " , " + humidity.ToString() + " , " + pressure.ToString());
        }
    }
}