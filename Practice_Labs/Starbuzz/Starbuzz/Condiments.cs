namespace Starbuzz
{


    public class Mocha : BeverageDecorator//, IOverrideDescription
    {
        Beverage _beverage;
        private const double AdditionalPrice = .20;

        public Mocha(Beverage beverage)
        {
            this._beverage = beverage;
        }



        override public string GetDescription()
        {
            return _beverage.GetDescription() + ", Mocha";
        }

        public override double Cost()
        {
            // compute the final cost with this added in
            return this._beverage.Cost() + AdditionalPrice;
        }
    }

    public interface IOverrideDescription
    {
        /// <summary>
        /// BE SURE TO override string GetDescription() to ensure it's feeding from the Beverage Baseclass
        /// </summary>
        /// <returns></returns>
        string GetDescription();
    }

    public class SteamedMilk : BeverageDecorator
    {
        private readonly Beverage _beverage;
        private const double AdditionalPrice = .10;

        public SteamedMilk(Beverage beverage)
        {
            _beverage = beverage;
        }

        public override string GetDescription()
        {
            return _beverage.GetDescription() + ", Steamed Milk";
        }

        public override double Cost()
        {
            // compute the final cost with this added in
            return _beverage.Cost() + AdditionalPrice;
        }
    }

    public class Soy : BeverageDecorator
    {
        private readonly Beverage _beverage;
        private const double AdditionalPrice = .15;

        public Soy(Beverage beverage)
        {
            _beverage = beverage;
        }

        // how to do i force this to get overridden? if i put it in the 
        // BeverageDecorator as an abstract, it overrides the base.
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

    public class Whip : BeverageDecorator
    {
        private readonly Beverage _beverage;
        private const double AdditionalPrice = .10;

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