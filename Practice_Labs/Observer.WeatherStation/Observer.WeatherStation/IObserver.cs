using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer.WeatherStation
{
   public interface IObserver
    {

        void update(float temp, float humidity, float pressure);
    }

    public class CurrentConditionsDisplay : IObserver, IDisplayElement
    {
        private float _temperature;
        private float _humidity;
        private ISubject _weatherData;

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            _weatherData = weatherData;
            _weatherData.registerObserver(this);
        }
        public void update(float temp, float humidity, float pressure)
        {
            this._temperature = temp;
            this._humidity = humidity;
            display();
        }

        public void display()
        {
            Console.WriteLine("Current Conditions: " + _temperature + "F degrees and " + _humidity + "% humidity");
        }
    }

    public class ForecastDisplay : IObserver, IDisplayElement
    {
        private float _temperature;
        private float _humidity;
        private ISubject _weatherData;

        public ForecastDisplay(ISubject weatherData)
        {
            _weatherData = weatherData;
            _weatherData.registerObserver(this);
        }
        public void update(float temp, float humidity, float pressure)
        {
            this._temperature = temp;
            this._humidity = humidity;
            display();
        }

        public void display()
        {
            Console.WriteLine("Current Forecast: " + _temperature + "F degrees and " + _humidity + "% humidity");
        }
    }

    public class StatisticsDisplay : IObserver, IDisplayElement
    {
        private float _temperature;
        private float _humidity;
        private ISubject _weatherData;
        private IList<float> historicalTemps;

        public StatisticsDisplay(ISubject weatherData)
        {
            _weatherData = weatherData;
            _weatherData.registerObserver(this);
            if(historicalTemps==null)historicalTemps = new List<float>();
        }
        public void update(float temp, float humidity, float pressure)
        {
            this._temperature = temp; historicalTemps.Add(temp);
            this._humidity = humidity;
            display();
        }

        public void display()
        {
            Console.WriteLine(" == STATISTICS ++ ");
            Console.WriteLine("Avg/Max/Min temperatures: {0}/{1}/{2}", historicalTemps.Average(), historicalTemps.Max(), historicalTemps.Min());
            Console.WriteLine("of {0} total temperature Readings", historicalTemps.Count);

        }
    }
}
