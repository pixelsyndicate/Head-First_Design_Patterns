using System;
using System.Configuration;

namespace HeadFirstDesignPatterns.TemplateMethod.CaffeineBeverage
{
	/// <summary>
	/// Summary description for TeaWithHook.
	/// </summary>
	public class TeaWithHook : CaffeineBeverageWithHook
	{
		public TeaWithHook()
		{}

		public override string Brew()
		{
			return "Steeping the tea\n";
		}

		public override string AddCondiments()
		{
			return "Adding lemon\n";
		}

		public override bool CustomerWantsCondiments()
		{
			return true;
		}

	}
}
