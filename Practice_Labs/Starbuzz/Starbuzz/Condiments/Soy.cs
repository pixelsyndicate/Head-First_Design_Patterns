using Starbuzz.Abstract;

namespace Starbuzz.Condiments
{
    public class Soy : BeverageDecorator
    {
        private const double AdditionalPrice = .15;
        private readonly Beverage _beverage;

        public Soy(Beverage beverage)
        {
            _beverage = beverage;
        }

        // how to do i force this to get overridden? 
        // WARNING: if i put it in the BeverageDecorator as an abstract, it overrides the base.
        // SO DONT
        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Soy";
        }

        public override double Cost()
        {
            // compute the final cost with this added in
            return _beverage.Cost() + AdditionalPrice;
        }
    }
}