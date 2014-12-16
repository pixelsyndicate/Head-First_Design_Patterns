using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            // the simple factory now is obsolete! I'm using a factory Method

            //if (type.Equals("cheese"))
            //    _pizza = new CheesePizza();
            //if (type.Equals("cheese"))
            //    _pizza = new PepperoniPizza();
            //if (type.Equals("cheese"))
            //    _pizza = new ClamPizza();
            //if (type.Equals("cheese"))
            //    _pizza = new VeggiePizza(); 
            return _pizza;

        }

    }

    //class PepperoniPizza : Pizza
    //{
    //    public PepperoniPizza()
    //        : base()
    //    {
    //        name = "Pepperoni Pizza";
    //        dough = "Thin Crust Dough";
    //        sauce = "Marinara Sauce";

    //        toppings.Add("Cheese");
    //        toppings.Add("Pepperoni");
    //    }


    //    public override void Prepare()
    //    {
    //        throw new NotImplementedException();
    //    }
    //}

    //class ClamPizza : Pizza
    //{
    //    public ClamPizza()
    //        : base()
    //    {

    //        name = "Clam Pizza";
    //        dough = "Thick Crust Dough";
    //        sauce = "Tartar Sauce";

    //        toppings.Add("Cheese");
    //        toppings.Add("Pepperoni");

    //    }


    //    public override void Prepare()
    //    {
    //        Console.WriteLine("Preparing " + name);
    //        Console.WriteLine("Tossing dough... ");
    //        Console.WriteLine("Adding sauce...");
    //        Console.WriteLine("Adding toppings...");
    //        foreach (var topping in toppings)
    //        {
    //            Console.WriteLine("         " + topping);
    //        }
    //    }
    //}

    //class VeggiePizza : Pizza
    //{
    //    public VeggiePizza()
    //        : base()
    //    {
    //        name = "Pepperoni Pizza";
    //        dough = "Thin Crust Dough";
    //        sauce = "Marinara Sauce";

    //        toppings.Add("Oregano");
    //    }


    //    public override void Prepare()
    //    {

    //        Console.WriteLine("Preparing " + name);
    //        Console.WriteLine("Tossing ");
    //        Console.WriteLine("Adding sauce...");
    //        Console.WriteLine("Adding toppings...");
    //        foreach (var topping in toppings)
    //        {
    //            Console.WriteLine("         " + topping);
    //        }

    //    }
    //}

    //class CheesePizza : Pizza
    //{
    //    public CheesePizza()
    //        : base()
    //    {
    //        name = "Cheese Pizza";
    //        dough = ingredientFactory.CreateDough();
    //        sauce = ingredientFactory.CreateSauce();
    //        cheese = ingredientFactory.CreateCheese();

    //        toppings.Add("lots of cheese");
    //        toppings.Add("More Cheese");
    //    }

    //    public override void Prepare()
    //    {
    //        // do stuff
    //    }

    //}

    //class ChicagoStyleCheesePizza : CheesePizza
    //{
    //    public ChicagoStyleCheesePizza()
    //        : base()
    //    {
    //        name += ", Chicago Style";
    //        dough = "Extra Thick Crust Dough";
    //        sauce = "Plumb Sauce";
    //        toppings.Add("Shredded Mozzarella Cheese");

    //    }
    //}

    //class ChicagoStylePepperoniPizza : PepperoniPizza
    //{
    //    public ChicagoStylePepperoniPizza()
    //        : base()
    //    {
    //        name += ", Chicago Style";
    //        dough = "Extra Thick Crust Dough";
    //        sauce = "Plumb Sauce";
    //        toppings.Add("Shredded Mozzarella Cheese");
    //    }

    //    public override void Prepare()
    //    {
    //        Console.WriteLine("Preparing " + name);
    //        Console.WriteLine("Tossing dough... ");
    //        Console.WriteLine("Adding sauce...");
    //        Console.WriteLine("Adding toppings...");
    //        foreach (var topping in toppings)
    //        {
    //            Console.WriteLine("         " + topping);
    //        }
    //    }

    //    public override void Cut()
    //    {
    //        Console.WriteLine("Cutting the pizza into square slices");
    //    }
    //}

    //class ChicagoStyleClamPizza : ClamPizza
    //{
    //    public ChicagoStyleClamPizza()
    //        : base()
    //    {
    //        name += ", Chicago Style";
    //        dough = "Extra Thick Crust Dough";
    //        sauce = "Plumb Sauce";
    //        toppings.Add("Shredded Mozzarella Cheese");
    //    }

    //    public override void Prepare()
    //    {
    //        Console.WriteLine("Preparing " + name);
    //        Console.WriteLine("Tossing dough... ");
    //        Console.WriteLine("Adding sauce...");
    //        Console.WriteLine("Adding toppings...");
    //        foreach (var topping in toppings)
    //        {
    //            Console.WriteLine("         " + topping);
    //        }
    //    }

    //    public override void Cut()
    //    {
    //        Console.WriteLine("Cutting the pizza into square slices");
    //    }
    //}

    //class ChicagoStyleVeggiePizza : VeggiePizza
    //{
    //    public ChicagoStyleVeggiePizza()
    //        : base()
    //    {
    //        name += ", Chicago Style";
    //        dough = "Extra Thick Crust Dough";
    //        sauce = "Plumb Sauce";
    //        toppings.Add("Shredded Mozzarella Cheese");
    //    }

    //    public override void Prepare()
    //    {
    //        Console.WriteLine("Preparing " + name);
    //        Console.WriteLine("Tossing dough... ");
    //        Console.WriteLine("Adding sauce...");
    //        Console.WriteLine("Adding toppings...");
    //        foreach (var topping in toppings)
    //        {
    //            Console.WriteLine("         " + topping);
    //        }
    //    }

    //    public override void Cut()
    //    {
    //        Console.WriteLine("Cutting the pizza into square slices");
    //    }
    //}

    //class NyStyleCheesePizza : CheesePizza
    //{
    //    public NyStyleCheesePizza()
    //        : base()
    //    {
    //        name += ", NY Style";
    //        toppings.Add("Grated Reggiano Cheese");
    //    }

    //}

    //class NyStylePepperoniPizza : PepperoniPizza
    //{
    //    public NyStylePepperoniPizza()
    //        : base()
    //    {
    //        name += ", NY Style";
    //        toppings.Add("Grated Reggiano Cheese");
    //    }

    //    public override void Prepare()
    //    {
    //        Console.WriteLine("Preparing " + name);
    //        Console.WriteLine("Tossing dough... ");
    //        Console.WriteLine("Adding sauce...");
    //        Console.WriteLine("Adding toppings...");
    //        foreach (var topping in toppings)
    //        {
    //            Console.WriteLine("         " + topping);
    //        }
    //    }
    //}

    //class NyStyleClamPizza : ClamPizza
    //{
    //    public NyStyleClamPizza()
    //        : base()
    //    {
    //        name += ", NY Style";
    //        toppings.Add("Grated Reggiano Cheese");
    //    }
    //}

    //class NyStyleVeggiePizza : VeggiePizza
    //{
    //    public NyStyleVeggiePizza()
    //        : base()
    //    {
    //        name += ", NY Style";
    //        toppings.Add("Grated Reggiano Cheese");
    //    }

    //    public override void Prepare()
    //    {
    //        Console.WriteLine("Preparing " + name);
    //        Console.WriteLine("Tossing dough... ");
    //        Console.WriteLine("Adding sauce...");
    //        Console.WriteLine("Adding toppings...");
    //        foreach (var topping in toppings)
    //        {
    //            Console.WriteLine("         " + topping);
    //        }
    //    }
    //}
}
