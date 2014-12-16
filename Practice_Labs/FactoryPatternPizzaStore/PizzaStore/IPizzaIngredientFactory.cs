using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PizzaStore
{
    // if we had some common 'machinery' to implement in each instance of factory, we could have made this an abstract class.
    public interface IPizzaIngredientFactory
    {
        // lots of new classes indicated here. one per ingredient. This will allow use to make regional differences in our concrete products
        Dough CreateDough();
        Sauce CreateSauce();
        Cheese CreateCheese();
        Veggies[] CreateVeggies();
        Pepperoni CreatePepperoni();
        Clams CreateClam();

    }


}
