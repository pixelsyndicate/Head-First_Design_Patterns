﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    class Program
    {
        static void Main(string[] args)
        {

            PizzaStoreFactory nyStore = new NyStylePizzaStore();
            PizzaStoreFactory chicagoStore = new ChicagoStylePizzaStore();


            Pizza pizza = nyStore.OrderPizza("cheese");
            Console.WriteLine("Ethan ordered a " + pizza.GetName() + Environment.NewLine);
            Console.WriteLine("   ");

            pizza = chicagoStore.OrderPizza("clam");
            Console.WriteLine("Joel ordered a " + pizza.GetName() + Environment.NewLine);
            Console.WriteLine("   ");

            Console.WriteLine("Press ENTER to close this...");
            Console.ReadLine();
        }
    }
}
