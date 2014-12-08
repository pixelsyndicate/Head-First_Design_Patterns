using System;
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
}