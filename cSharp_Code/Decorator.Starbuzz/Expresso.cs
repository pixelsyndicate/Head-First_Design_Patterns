using System;
using System.Configuration;

namespace HeadFirstDesignPatterns.Decorator.Starbuzz
{
	/// <summary>
	/// Summary description for Expresso.
	/// </summary>
	public class Expresso: Beverage
	{
		public Expresso()
		{}

		public override double Cost()
		{
			return GetSize(base.Size);
		}

		public override string GetDescription()
		{
			return "Expresso";
		}

		private double GetSize(BeverageSize size)
		{
			switch(size)
			{
                 case BeverageSize.TALL:
                    return 1.5 ;
                case BeverageSize.GRANDE:
                    return 1.75 ;
                case BeverageSize.VENTI:
                    return 3 ;
                default:
                    return 1.50;
			}
		}

	}
}
