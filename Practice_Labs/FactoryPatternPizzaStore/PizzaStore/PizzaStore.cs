using System.Dynamic;

namespace PizzaStore
{
    /// <summary>
    /// This is a stand-alone pizza store using a SimplePizzaFactory
    /// </summary>
    public class PizzaStore
    {
        private readonly SimplePizzaFactory _factory;

        public PizzaStore(SimplePizzaFactory factory)
        {
            _factory = factory;
        }

        public Pizza OrderPizza(string type)
        {

            // note we aren't using the NEW keyword here.
            Pizza pizza = _factory.CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }
    }


    public class NyStylePizzaStore : PizzaStoreFactory
    {
        public override Pizza CreatePizza(string type)
        {
            pizza = null;
            IPizzaIngredientFactory ingredientFactory = new NyPizzaIngredientFactory();

            if (type.Equals("cheese"))
            {
                pizza = new CheesePizza(ingredientFactory);
                pizza.setName("New York Style Cheese Pizza");
            }
            if (type.Equals("pepperoni"))
            {
                pizza = new PepperoniPizza(ingredientFactory);
                pizza.setName("The Ny Classic Pepperoni");

            }
            if (type.Equals("clam"))
            {
                pizza = new ClamPizza(ingredientFactory);
                pizza.setName("NY clam Pizza Oceanview");
            }
            if (type.Equals("veggie"))
            {
                pizza = new VeggiePizza(ingredientFactory);
                pizza.setName("NY Veggie Pie");
            }


            return pizza;
        }
    }

    public class ChicagoStylePizzaStore : PizzaStoreFactory
    {
        public override Pizza CreatePizza(string type)
        {

            pizza = null;
            IPizzaIngredientFactory ingredientFactory = new NyPizzaIngredientFactory();

            if (type.Equals("cheese"))
            {
                pizza = new CheesePizza(ingredientFactory);
                pizza.setName("Chicago Style Cheese Pizza");
            }
            if (type.Equals("pepperoni"))
            {
                pizza = new PepperoniPizza(ingredientFactory);
                pizza.setName("The Chicago Classic Pepperoni");

            }
            if (type.Equals("clam"))
            {
                pizza = new ClamPizza(ingredientFactory);
                pizza.setName("Chicago Pizza Shipped In Cans Clams");
            }
            if (type.Equals("veggie"))
            {
                pizza = new VeggiePizza(ingredientFactory);
                pizza.setName("Chicago Veggie Pie");
            }


            return pizza;
        }
    }
}