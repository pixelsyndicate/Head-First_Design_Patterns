using System;
using Starbuzz.Abstract;
using Starbuzz.Beverages;
using Starbuzz.Condiments;

namespace Starbuzz
{
    internal class Program
    {
        private static void Main()
        {
            // use the abstract class to hold the implimentation
            Console.WriteLine("New Customer Order :");
            Beverage esp = new Espresso();
            esp = new Sugar(esp);
            Console.WriteLine(esp.GetDescription() + " $" + esp.Cost());
            Console.WriteLine();


            // use the abstract class to hold the implimentation
            Console.WriteLine("New Customer Order :");
            Beverage espSteamed = new Espresso();
            espSteamed = new SteamedMilk(espSteamed);
            Console.WriteLine(espSteamed.GetDescription() + " $" + espSteamed.Cost());
            Console.WriteLine();



            // use the abstract class to hold the implimentation
            Console.WriteLine("New Customer Order :");
            Beverage drkrstPlain = new DarkRoast();
            Console.WriteLine(drkrstPlain.GetDescription() + " $" + drkrstPlain.Cost());

            // make changes, just by wrapping more complexity
            Console.WriteLine("Customer Changed Order : What is the cost with adding condiments?");
            drkrstPlain = new Mocha(drkrstPlain);
            Console.WriteLine("Price for " + drkrstPlain.GetDescription() + " would be $" + drkrstPlain.Cost());
            drkrstPlain = new Soy(drkrstPlain);
            Console.WriteLine("Price for " + drkrstPlain.GetDescription() + " would be $" + drkrstPlain.Cost());
            drkrstPlain = new Whip(drkrstPlain);
            Console.WriteLine("Price for " + drkrstPlain.GetDescription() + " would be $" + drkrstPlain.Cost());
            Console.WriteLine();


            // use the abstract class to hold the implimentation
            Console.WriteLine("New Customer Order : triple-mocha-decaf!!?");
            Beverage tripleDecafMocha = new Decaf();
            tripleDecafMocha = new Mocha(tripleDecafMocha);
            tripleDecafMocha = new Mocha(tripleDecafMocha);
            tripleDecafMocha = new Mocha(tripleDecafMocha);
            Console.WriteLine(tripleDecafMocha.GetDescription() + " $" + tripleDecafMocha.Cost());
            Console.WriteLine();

       

            Console.WriteLine();
            Console.WriteLine("Press ENTER to close this");
            Console.WriteLine("...");
            Console.ReadLine();
        }




        // why not use extension methods to add mocha?
        // e.g. tripleDecafMocha.AddMocha().AddMocha().AddMocha()
        // Extension methods are not a replacement for the decorator pattern: 
        // Extension methods work to provide functionality to an existing type without having to create a derived type.
        // Other options would to create a Visitor Pattern (which then works hand-in-hand with a traverser pattern)


    }

}