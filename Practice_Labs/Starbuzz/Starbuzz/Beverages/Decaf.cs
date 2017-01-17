using Starbuzz.Abstract;

namespace Starbuzz.Beverages
{
    public class Decaf : Beverage
    {
        public Decaf()
        {
            // take care of the local assignment of the product name.
            Description = "Decaffinated Coffee";
        }

        public override double Cost()
        {
            // compute the cost of the beverage. we doint need to worry about the  condiments here.
            return 1.05;
        }
    }
}