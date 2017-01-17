namespace Starbuzz.Abstract
{
    public class Sugar : BeverageDecorator
    {
        private readonly Beverage _beverage;

        public Sugar(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override double Cost()
        {
            return _beverage.Cost() + .10;
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + " w/ Sugar";
        }
    }
}