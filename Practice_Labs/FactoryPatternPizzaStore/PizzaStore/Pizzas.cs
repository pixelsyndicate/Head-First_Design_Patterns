using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace PizzaStore
{
    public abstract class Pizza
    {
        public string name;
        public string dough;
        public string sauce;
        protected IList<string> toppings = new List<string>();

        protected Pizza()
        {
            this.toppings = toppings;
        }


        public virtual void Prepare()
        {
            Console.WriteLine("Preparing " + name);
            Console.WriteLine("Tossing dough... ");
            Console.WriteLine("Adding sauce...");
            Console.WriteLine("Adding toppings...");
            foreach (var topping in toppings)
            {
                Console.WriteLine("         " + topping);
            }
        }

        public virtual void Bake()
        {
            Console.WriteLine("Bake for 25 minutes at 350");
        }

        public virtual void Cut()
        {
            Console.WriteLine("Cutting the pizza into diagonal slices");
        }

        public virtual void Box()
        {
            Console.WriteLine("Placing pizza in official PizzaStore boxes");
        }

        public string GetName()
        {
            return name;
        }
    }

    class PepperoniPizza : Pizza
    {
        public PepperoniPizza() : base()
        {
            name = "Pepperoni Pizza";
            dough = "Thin Crust Dough";
            sauce = "Marinara Sauce";

            toppings.Add("Cheese");
            toppings.Add("Pepperoni");
        }

       
    }

    class ClamPizza : Pizza
    {
        public ClamPizza() : base()
        {

            name = "Clam Pizza";
            dough = "Thick Crust Dough";
            sauce = "Tartar Sauce";

            toppings.Add("Cheese");
            toppings.Add("Pepperoni");

        }

   
    }

    class VeggiePizza : Pizza
    {
        public VeggiePizza() : base()
        {
            name = "Pepperoni Pizza";
            dough = "Thin Crust Dough";
            sauce = "Marinara Sauce";

            toppings.Add("Oregano");
        }

    
    }

    class CheesePizza : Pizza
    {
        public CheesePizza() : base()
        {
            name = "Cheese Pizza";
            dough = "Thin Crust Dough";
            sauce = "Marinara Sauce";

            toppings.Add("Logs of Cheese");
            toppings.Add("More Cheese");
        }

        public override void Prepare()
        {
            // do stuff
        }

    }

    class ChicagoStyleCheesePizza : CheesePizza
    {
        public ChicagoStyleCheesePizza() : base()
        {
            name += ", Chicago Style";
            dough = "Extra Thick Crust Dough";
            sauce = "Plumb Sauce";
            toppings.Add("Shredded Mozzarella Cheese");

        }
    }

    class ChicagoStylePepperoniPizza : PepperoniPizza
    {
        public ChicagoStylePepperoniPizza() : base()
        {
            name += ", Chicago Style";
            dough = "Extra Thick Crust Dough";
            sauce = "Plumb Sauce";
            toppings.Add("Shredded Mozzarella Cheese");
        }

        public override void Cut()
        {
            Console.WriteLine("Cutting the pizza into square slices");
        }
    }

    class ChicagoStyleClamPizza : ClamPizza
    {
        public ChicagoStyleClamPizza() : base()
        {
            name += ", Chicago Style";
            dough = "Extra Thick Crust Dough";
            sauce = "Plumb Sauce";
            toppings.Add("Shredded Mozzarella Cheese");
        }
        public override void Cut()
        {
            Console.WriteLine("Cutting the pizza into square slices");
        }
    }

    class ChicagoStyleVeggiePizza : VeggiePizza
    {
        public ChicagoStyleVeggiePizza() : base()
        {
            name += ", Chicago Style";
            dough = "Extra Thick Crust Dough";
            sauce = "Plumb Sauce";
            toppings.Add("Shredded Mozzarella Cheese");
        }
        public override void Cut()
        {
            Console.WriteLine("Cutting the pizza into square slices");
        }
    }

    class NyStyleCheesePizza : CheesePizza
    {
        public NyStyleCheesePizza() : base()
        {
            name += ", NY Style";
            toppings.Add("Grated Reggiano Cheese");
        }

    }

    class NyStylePepperoniPizza : PepperoniPizza
    {
        public NyStylePepperoniPizza() : base()
        {
            name += ", NY Style";
            toppings.Add("Grated Reggiano Cheese");
        }
    }

    class NyStyleClamPizza : ClamPizza
    {
        public NyStyleClamPizza() : base()
        {
            name += ", NY Style";
            toppings.Add("Grated Reggiano Cheese");
        }
    }

    class NyStyleVeggiePizza : VeggiePizza
    {
        public NyStyleVeggiePizza() : base()
        {
            name += ", NY Style";
            toppings.Add("Grated Reggiano Cheese");
        }
    }
}