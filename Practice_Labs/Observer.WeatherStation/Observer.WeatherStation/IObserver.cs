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

        public CurrentConditionsDisplay(ISubject weatherData)
        {
            weatherData.registerObserver(this);
        }

        public void update(float temp, float humidity, float pressure)
        {
            this._temperature = temp;
            this._humidity = humidity;
            display();
        }

        public void display()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" == CURRENT CONDITIONS === ");
            Console.WriteLine("Its " + _temperature + " F degrees and " + _humidity + " % humidity");
        }
    }

    public class ForecastDisplay : IObserver, IDisplayElement
    {
        private float _temperature;
        private float _humidity;
        private float _pressure;
        private ISubject _weatherData;
        private readonly IList<float> historicalPressure;

        public ForecastDisplay(ISubject weatherData)
        {
            _weatherData = weatherData;
            _weatherData.registerObserver(this);
            if (historicalPressure == null)
            {
                historicalPressure = new List<float>();
            }
        }

        public void update(float temp, float humidity, float pressure)
        {
            this._temperature = temp;
            this._humidity = humidity;
            this._pressure = pressure;
            historicalPressure.Add(pressure);
            display();
        }

        public void display()
        {
            var currentPressure = historicalPressure.Last();
            var currentIndex = historicalPressure.IndexOf(currentPressure);
            Console.WriteLine(" ");
            Console.WriteLine(" == FORECAST == ");
            try
            {
                var previousPressure = historicalPressure[currentIndex - 1];

                if (Math.Abs(currentPressure - previousPressure) < .01)
                    Console.WriteLine("Forecast: Looks like we are in for more of the same. (p{0}/c{1})",
                        previousPressure, currentPressure);
                if (currentPressure >= previousPressure)
                    Console.WriteLine("Forecast: Looks like we may be in for cooler and clear weather. (p{0}/c{1})",
                        previousPressure, currentPressure);
                if (currentPressure <= previousPressure)
                    Console.WriteLine("Forecast: Looks like we may be in some stormy weather. (p{0}/c{1})",
                        previousPressure, currentPressure);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Forecast: Looks like we are in for more of the same.");
            }
        }
    }

    public class StatisticsDisplay : IObserver, IDisplayElement
    {
        private float _temperature;
        private float _humidity;
        private ISubject _weatherData;
        private readonly IList<float> historicalTemps;

        public StatisticsDisplay(ISubject weatherData)
        {
            _weatherData = weatherData;
            _weatherData.registerObserver(this);
            if (historicalTemps == null) historicalTemps = new List<float>();
        }

        public void update(float temp, float humidity, float pressure)
        {
            this._temperature = temp;
            historicalTemps.Add(temp);
            this._humidity = humidity;
            display();
        }

        public void display()
        {
            Console.WriteLine(" ");
            Console.WriteLine(" == STATISTICS === ");
            Console.WriteLine("Avg/Max/Min temperatures: {0}/{1}/{2}", historicalTemps.Average(), historicalTemps.Max(),
                historicalTemps.Min());
            Console.WriteLine("of {0} total temperature Readings", historicalTemps.Count);
        }
    }

    public class HeatIndexDisplay : IObserver, IDisplayElement
    {
        private float _temperature;
        private float _humidity;
        private ISubject _weatherData;

        public HeatIndexDisplay(ISubject weatherData)
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
            var temperatureSquared = _temperature*_temperature;
            var humiditySquared = _humidity*_humidity;
            var heatIndex = -42.379
                            + 2.04901523*_temperature
                            + 10.14333127*_humidity
                            - 0.22475541*_temperature*_humidity
                            - 6.83783e-3*temperatureSquared
                            - 5.481717e-2*humiditySquared
                            + 1.22874e-3*temperatureSquared*_humidity
                            + 8.5282e-4*_temperature*humiditySquared
                            - 1.99e-6*temperatureSquared*humiditySquared;

            Console.WriteLine(" ");
            Console.WriteLine(" == HEAT INDEX === ");
            Console.WriteLine("Its feeling about " + heatIndex + " F degrees right now.");
        }
    }
}