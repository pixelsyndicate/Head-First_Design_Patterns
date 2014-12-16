using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace PizzaStore
{
    public abstract class Pizza
    {

        internal string name;
        public Dough dough;
        public Sauce sauce;
        public Veggies[] veggies;
        public Cheese cheese;
        public Pepperoni pepperoni;
        public Clams clams;
        protected IPizzaIngredientFactory _ingredientFactory;

        // protected IList<string> toppings = new List<string>();

        //protected Pizza()
        //{
        //    this.toppings = toppings;
        //}


        public abstract void Prepare();
        

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

        public void setName(string pizzaName)
        {
            name = pizzaName;
        }
    }


}