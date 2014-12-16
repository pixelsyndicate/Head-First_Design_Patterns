using System;
using System.Collections.Generic;

namespace PizzaStore
{
    class ChicagoPizzaIngredientFactory : IPizzaIngredientFactory{
        public Dough CreateDough()
        {
            return new ThickCrustDough();
        }

        public Sauce CreateSauce()
        {
            return new PlumTomatoSauce();
        }

        public Cheese CreateCheese()
        {
            return new MozzarellaCheese();
        }

        public Veggies[] CreateVeggies()
        {
            Veggies[] veggies =  new List<Veggies>() {new EggPlant(), new BlackOlives(), new Mushrooms(), new Spinach() }.ToArray();
            return veggies;
        }

        public Pepperoni CreatePepperoni()
        {
            return new ThickSlicedPepperoni();
        }

        public Clams CreateClam()
        {
            return new FrozenClams();
        }
    }

    
    class NyPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public Dough CreateDough()
        {
            return new ThinCrustDough();
        }

        public Sauce CreateSauce()
        {
            return new MarinaraSauce();
        }

        public Cheese CreateCheese()
        {
            return new ReggianoCheese();
        }

        public Veggies[] CreateVeggies()
        {
            Veggies[] veggies =  new List<Veggies>() {new Garlic(), new Onion(), new Mushrooms(), new RedPeppers() }.ToArray();
            return veggies;
        }

        public Pepperoni CreatePepperoni()
        {
            return new ThinSlicedPepperoni();
        }

        public Clams CreateClam()
        {
            return new FreshClams();
        }
    }



    class CaliforniaPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public Dough CreateDough()
        {
            throw new NotImplementedException();
        }

        public Sauce CreateSauce()
        {
            throw new NotImplementedException();
        }

        public Cheese CreateCheese()
        {
            throw new NotImplementedException();
        }

        public Veggies[] CreateVeggies()
        {
            throw new NotImplementedException();
        }

        public Pepperoni CreatePepperoni()
        {
            throw new NotImplementedException();
        }

        public Clams CreateClam()
        {
            throw new NotImplementedException();
        }
    }

  
}