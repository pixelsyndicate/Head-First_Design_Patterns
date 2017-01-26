#region USING DIRECTIVES (collapse to hide)

using System;

#endregion

namespace tmpConsole.CaffinatedBeverages
{
    /// <summary>
    ///     AbstractClass contains the template method.
    ///     And abstract versions of the operations used in the template method.
    /// </summary>
    public abstract class CaffeinBeverage
    {
        /// <summary>
        ///     This is the TEMPLATE METHOD.
        ///     Must be NON-VIRTUAL (similar to being marked as 'final' in Java) so that subclasses cannot rework the process.
        /// </summary>
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            AddCondiments();
        }

        /// <summary>
        ///     abstract version of the operations used in the template method.
        /// </summary>
        public abstract void Brew();

        /// <summary>
        ///     abstract version of the operations used in the template method.
        /// </summary>
        public abstract void AddCondiments();


        public virtual void BoilWater()
        {
            // implementation can be done in the ConcreteClass
            Console.WriteLine("Putting water on to boil.");
        }

        public virtual void PourInCup()
        {
            // implementation can be done in the ConcreteClass
            Console.WriteLine("Pouring beverage into a cup.");
        }
    }


    /// <summary>
    ///     AbstractClass contains the template method.
    ///     And abstract versions of the operations used in the template method.
    /// </summary>
    public abstract class CaffeinBeverageWithHook
    {
        /// <summary>
        ///     This is the TEMPLATE METHOD.
        ///     Must be NON-VIRTUAL (similar to being marked as 'final' in Java) so that subclasses cannot rework the process.
        /// </summary>
        public void PrepareRecipe()
        {
            BoilWater();
            Brew();
            PourInCup();
            // use of HOOK method here allows some change to the algorithm 
            // if subclass impliments their own version of the HOOK
            if (CustomerWantsCondiments())
                AddCondiments();
        }

        /// <summary>
        ///     abstract version of the operations used in the template method.
        /// </summary>
        public abstract void Brew();

        /// <summary>
        ///     abstract version of the operations used in the template method.
        /// </summary>
        public abstract void AddCondiments();


        public virtual void BoilWater()
        {
            // implementation can be done in the ConcreteClass
            Console.WriteLine("Putting water on to boil.");
        }

        public virtual void PourInCup()
        {
            // implementation can be done in the ConcreteClass
            Console.WriteLine("Pouring beverage into a cup.");
        }

        /// <summary>
        ///     We can have concrete methods that do nothing by default; we call these 'hooks'.
        ///     Subclasses are free to override these but don't have to. MUST be marked as virtual to be overridden.
        /// </summary>
        public virtual bool CustomerWantsCondiments()
        {
            return true;
        }
    }

    public class Coffee : CaffeinBeverage
    {
        public override void Brew()
        {
            Console.WriteLine("Brew your beans in the hot water.");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("Adding cream to cup.");
            Console.WriteLine("Adding sugar to cup.");
        }
    }


    public class Tea : CaffeinBeverage
    {
        public override void Brew()
        {
            Console.WriteLine("Steep the leaves in the hot water.");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("Squeezing in a bit of lemon to the tea cup.");
            Console.WriteLine("Adding sugar to cup to the tea cup.");
        }
    }

    // test - making base customerwantscondiments() virtual and then marking as NEW - didn't work
    public class CoffeeWithHook : CaffeinBeverageWithHook
    {
        public override void Brew()
        {
            Console.WriteLine("Brew your beans in the hot water.");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("Adding cream to cup.");
            Console.WriteLine("Adding sugar to cup.");
        }

        /// <summary>
        ///     Here's our override of the HOOK
        ///     Determine it's return based on implimentation of user input.
        /// </summary>
        /// <returns></returns>
        public override bool CustomerWantsCondiments()
        {
            string answer = getUserInput();

            return answer.ToLower().StartsWith("y");
        }

        private string getUserInput()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like Milk and Sugar with your coffee (y/n)? ");

            return Console.ReadLine();
        }
    }

    // test - making base customerwantscondiments() virtual and then marking as OVERRIDE - worked.
    public class TeaWithHook : CaffeinBeverageWithHook
    {
        public override void Brew()
        {
            Console.WriteLine("Steep the leaves in the hot water.");
        }

        public override void AddCondiments()
        {
            Console.WriteLine("Squeezing in a bit of lemon to the tea cup.");
            Console.WriteLine("Adding sugar to cup to the tea cup.");
        }

        /// <summary>
        ///     Here's our override of the HOOK
        ///     Determine it's return based on implimentation of user input.
        /// </summary>
        /// <returns></returns>
        public override bool CustomerWantsCondiments()
        {
            string answer = getUserInput();

            return answer.ToLower().StartsWith("y");
        }

        private string getUserInput()
        {
            Console.WriteLine();
            Console.WriteLine("Would you like Lemon with your tea (y/n)? ");

            return Console.ReadLine();
        }
    }


    // the IComparable interface is an example where it forces 
    // design of helper component CompareTo() for the base Array.Sort().
    public class Duck : IComparable
    {
        private string Name { get; set; }
        private int Weight { get; set; }

        public override string ToString()
        {
            return Name + " weights " + Weight;
        }

        /// <summary>
        /// This is our implementation of IComparable, a low-level component so Sort() can work
        /// Here we specify how Ducks are compared to one another.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>0 if equal, -1 if less or 1 if greater</returns>
        public int CompareTo(object obj)
        {
            Duck otherDuck = (Duck)obj;
            if (this.Weight < otherDuck.Weight) { return -1; }
            else if (this.Weight == otherDuck.Weight) { return 0; }
            else // this.weight > otherduck.weight 
            { return 1; }
        }
    }
}