using Starbuzz.Abstract;

namespace Starbuzz.Condiments
{
    public class SteamedMilk : BeverageDecorator
    {
        private const double AdditionalPrice = .10;
        private readonly Beverage _beverage;

        public SteamedMilk(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Steamed Milk";
        }

        public override bool IsDairy()
        {
            return true;
        }

        public override double Cost()
        {
            // compute the final cost with this added in
            return _beverage.Cost() + AdditionalPrice;
        }
    }
}