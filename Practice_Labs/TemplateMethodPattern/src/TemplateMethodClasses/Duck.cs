using System;

namespace TemplateMethodClasses
{
    /// <summary>
    /// the IComparable interface is an example where it forces 
    /// design of helper component CompareTo() for the base Array.Sort().
    /// </summary>
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