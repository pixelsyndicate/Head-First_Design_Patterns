using System;
using System.Configuration;

namespace HeadFirstDesignPatterns.Decorator.Starbuzz
{
	/// <summary>
	/// Summary description for Mocha.
	/// </summary>
	public class Mocha : CondimentDecorator
	{
		Beverage beverage;
		
		public Mocha(Beverage beverage)
		{
			this.beverage = beverage;
		}

		public override string GetDescription()
		{
			return beverage.GetDescription() + ", Mocha";
		}

		public override double Cost()
		{
			return GetSize(base.Size);
		}

		private double GetSize(BeverageSize size)
		{
			switch(size)
			{
                case BeverageSize.TALL:
                    return Convert.ToDouble(".10") +
                        beverage.Cost();
                case BeverageSize.GRANDE:
                    return Convert.ToDouble(".15") +
                        beverage.Cost();
                case BeverageSize.VENTI:
                    return Convert.ToDouble(".20") +
                        beverage.Cost();
                default:
                    return .20;

			}
		}

	}
}
