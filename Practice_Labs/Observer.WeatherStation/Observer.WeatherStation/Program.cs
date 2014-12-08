using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Observer.WeatherStation
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            
            // this is my observable
            WeatherData weatherData = new WeatherData();

            // these are my observers
            CurrentConditionsDisplay currentDisplay = new CurrentConditionsDisplay(weatherData);
            StatisticsDisplay statisticsDisplay = new StatisticsDisplay(weatherData);
            ForecastDisplay forecastDisplay = new ForecastDisplay(weatherData);
            HeatIndexDisplay heatIndexDisplay = new HeatIndexDisplay(weatherData);

            // lets ask the observers subscribe to the event SomethingHappened
            weatherData.SomethingHappened += currentDisplay.HandleEvent;


            weatherData.setMeasurements(79, 65, 31.1f);
            weatherData.setMeasurements(81, 69, 30.4f);
            weatherData.setMeasurements(80, 65, 30.2f);
            weatherData.setMeasurements(82, 70, 29.2f);
            weatherData.setMeasurements(78, 90, 29.1f);
            weatherData.setMeasurements(80, 60, 30.3f);

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }
    }
}