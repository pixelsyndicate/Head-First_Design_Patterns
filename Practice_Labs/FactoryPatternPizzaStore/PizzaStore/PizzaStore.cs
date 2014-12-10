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


    public abstract class PizzaStores
    {
        internal protected Pizza pizza { get; set; }

        /// <summary>
        /// by passing "cheese', the OrderPizza() method will get a pizza from the subclass pizza store. So what you get back is dependent on what class is implimenting.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public Pizza OrderPizza(string type)
        {
            // this will go out to the subclass implementation to get back the particular implimentation requested.
            pizza = CreatePizza(type);

            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();

            return pizza;
        }

        /// <summary>
        /// Each subclass provides an implementation of the CreatePizza() method in PizzaStores
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public abstract Pizza CreatePizza(string type);



    }


    public class NyStylePizzaStore : PizzaStores
    {
        public override Pizza CreatePizza(string type)
        {

            if (type.Equals("cheese"))
                pizza = new NyStyleCheesePizza();
            if (type.Equals("cheese"))
                pizza = new NyStylePepperoniPizza();
            if (type.Equals("cheese"))
                pizza = new NyStyleClamPizza();
            if (type.Equals("cheese"))
                pizza = new NyStyleVeggiePizza();


            return pizza;
        }
    }

    public class ChicagoStylePizzaStore : PizzaStores
    {
        public override Pizza CreatePizza(string type)
        {

            if (type.Equals("cheese"))
                pizza = new ChicagoStyleCheesePizza();
            if (type.Equals("cheese"))
                pizza = new ChicagoStylePepperoniPizza();
            if (type.Equals("cheese"))
                pizza = new ChicagoStyleClamPizza();
            if (type.Equals("cheese"))
                pizza = new ChicagoStyleVeggiePizza();


            return pizza;
        }
    }
}