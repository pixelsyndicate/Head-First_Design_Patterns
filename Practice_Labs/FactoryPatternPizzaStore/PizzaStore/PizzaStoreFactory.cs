namespace PizzaStore
{
    public abstract class PizzaStoreFactory
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
}