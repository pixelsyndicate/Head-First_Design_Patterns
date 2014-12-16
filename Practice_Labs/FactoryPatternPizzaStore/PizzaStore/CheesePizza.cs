using System;

namespace PizzaStore
{
    public class CheesePizza : Pizza
    {
        

        public CheesePizza(IPizzaIngredientFactory ingredientFactory)
        {
            _ingredientFactory = ingredientFactory;


        }

        public override void Prepare()
        {
            Console.WriteLine("Preparing " + name);
            // the specifics are available only though the ingredient factory for the particular store type.
            dough = _ingredientFactory.CreateDough();
            sauce = _ingredientFactory.CreateSauce();
            cheese = _ingredientFactory.CreateCheese();
            // clams = _ingredientFactory.CreateClam();
        }

    }
}