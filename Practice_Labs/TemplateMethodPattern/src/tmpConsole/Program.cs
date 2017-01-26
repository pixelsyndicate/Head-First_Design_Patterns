using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tmpConsole.CaffinatedBeverages;

namespace tmpConsole
{
    public class Program
    {
        public static void Main(string[] args)
        {



            TakeOrder();

            // N was answer, closing.
            AwaitEnterForExit();

        }

        public static void TakeOrder()
        {
            Console.WriteLine(); Console.WriteLine();
            Console.WriteLine("Tea (T) or Coffee (C) or Nothing (N)?");
            Console.WriteLine("enter T, C or N");
            var responseBev = Console.ReadLine();
            Console.WriteLine(); Console.WriteLine();

            FufillOrder(responseBev);

        }

        private static void FufillOrder(string responseBev)
        {
            if (responseBev.ToLower() == "t")
            {
                Console.WriteLine("Preparing Tea");
                Console.WriteLine();

                // var tea = new CaffinatedBeverages.Tea();
                var tea = new CaffinatedBeverages.TeaWithHook();

                // here's use of the templatemethod
                tea.PrepareRecipe();

                // repeat question
                TakeOrder();
            }
            else if (responseBev.ToLower() == "c")
            {
                Console.WriteLine("Preparing Coffee");
                Console.WriteLine();

                // var coffee = new tmpConsole.CaffinatedBeverages.Coffee();
                var coffee = new tmpConsole.CaffinatedBeverages.CoffeeWithHook();


                // here's use of the templatemethod
                coffee.PrepareRecipe();

                // repeat question
                TakeOrder();
            }
            else if (responseBev.ToLower() != "n")
            {
                // repeat question
                TakeOrder();
            }
        }

        private static void AwaitEnterForExit()
        {
            Console.WriteLine();
            Console.WriteLine("Press ENTER to quit.");
            var response = Console.ReadLine();
        }
    }
}
