using Starbuzz.Abstract;

namespace Starbuzz.Beverages
{
    public class DarkRoast : Beverage
    {
        public DarkRoast()
        {
            // take care of the local assignment of the product name.
            Description = "Dark Roast Coffee";
        }

        public override double Cost()
        {
            // compute the cost of the beverage. we doint need to worry about the 
            // condiments here.
            return .99;
        }
    }
}