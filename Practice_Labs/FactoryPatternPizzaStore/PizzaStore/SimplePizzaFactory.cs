using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    public class SimplePizzaFactory
    {
        private Pizza _pizza;

        public SimplePizzaFactory(Pizza pizza)
        {
            _pizza = pizza;
        }

        public Pizza CreatePizza(String type)
        {
            if (type.Equals("cheese"))
                _pizza = new CheesePizza();
            if (type.Equals("cheese"))
                _pizza = new PepperoniPizza();
            if (type.Equals("cheese"))
                _pizza = new ClamPizza();
            if (type.Equals("cheese"))
                _pizza = new VeggiePizza(); return _pizza;

        }

    }
}
