namespace Starbuzz
{
    public class Espresso : Beverage
    {
        public Espresso()
        {
            // take care of the local assignment of the product name.
            Description = "Espresso";
        }

        public override double Cost()
        {
            // compute the cost of the beverage. we doint need to worry about the 
            // condiments here.
            return 1.99;
        }
    }

    public class HouseBlend : Beverage
    {
        public HouseBlend()
        {
            // take care of the local assignment of the product name.
            Description = "House Blend Coffee";
        }

        public override double Cost()
        {
            // compute the cost of the beverage. we doint need to worry about the 
            // condiments here.
            return .89;
        }
    }

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

    public class Decaf : Beverage
    {
        public Decaf()
        {
            // take care of the local assignment of the product name.
            Description = "Decaffinated Coffee";
        }

        public override double Cost()
        {
            // compute the cost of the beverage. we doint need to worry about the 
            // condiments here.
            return 1.05;
        }
    }
}