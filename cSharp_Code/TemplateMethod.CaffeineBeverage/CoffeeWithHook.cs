using System;
using System.Configuration;

namespace HeadFirstDesignPatterns.TemplateMethod.CaffeineBeverage
{
	/// <summary>
	/// Summary description for CoffeeWithHook.
	/// </summary>
	public class CoffeeWithHook : CaffeineBeverageWithHook
	{
		public CoffeeWithHook()
		{}

		public override string Brew()
		{
			return "Dripping coffee through filter\n";
		}

		public override string AddCondiments()
		{
			return "Adding sugar and milk\n";
		}

		public override bool CustomerWantsCondiments()
		{
			return true;
		}

	}
}
