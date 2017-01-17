using Starbuzz.Abstract;

namespace Starbuzz.Condiments
{
    public class Mocha : BeverageDecorator
        //, IOverrideDescription  <-- this is repetative since the base of the base is abstract
    {
        private const double AdditionalPrice = .20;
        private readonly Beverage _beverage;

        public Mocha(Beverage beverage)
        {
            _beverage = beverage;
        }


        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Mocha";
        }

        public override double Cost()
        {
            // compute the final cost with this added in
            return _beverage.Cost() + AdditionalPrice;
        }
    }
}