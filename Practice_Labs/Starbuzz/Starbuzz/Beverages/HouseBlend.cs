using Starbuzz.Abstract;

namespace Starbuzz.Beverages
{
    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            // take care of the local assignment of the product name.
            Description = "House Blend Coffee";
        }

        public override double Cost()
        {
            // compute the cost of the beverage. we dont need to worry about the condiments here.
            return .89;
        }
    }
}