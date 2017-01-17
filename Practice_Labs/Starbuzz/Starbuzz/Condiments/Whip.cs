using Starbuzz.Abstract;

namespace Starbuzz.Condiments
{
    public class Whip : BeverageDecorator
    {
        private const double AdditionalPrice = .10;
        private readonly Beverage _beverage;

        public Whip(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Whip";
        }

        public override double Cost()
        {
            // compute the final cost with this added in
            return _beverage.Cost() + AdditionalPrice;
        }
    }
}