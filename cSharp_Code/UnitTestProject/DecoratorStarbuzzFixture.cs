using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadFirstDesignPatterns.Decorator.Starbuzz;

namespace UnitTestProject
{
    [TestClass]
    public class DecoratorStarbuzzFixture
    {
        #region TestExpresso
        [TestMethod]
        public void TestExpresso()
        {
            Beverage beverage = new Expresso();
            Assert.AreEqual("Expresso $1.5", beverage.GetDescription() +
                " $" + beverage.Cost());
        }
        #endregion//TestExpresso

        #region TestExpressoWithSize
        [TestMethod]
        public void TestExpressoWithSize()
        {
            BeverageSize beverageSize = BeverageSize.GRANDE;
            Beverage beverage = new Expresso();
            beverage.Size = beverageSize;
            beverage = new Mocha(beverage);
            beverage.Size = beverageSize;
            Assert.AreEqual("Expresso, Mocha $1.9", beverage.GetDescription() +
                " $" + beverage.Cost());
        }
        #endregion//TestExpressoWithSize

        #region TestHouseBlend
        [TestMethod]
        public void TestHouseBlend()
        {
            Beverage beverage = new HouseBlend();
            beverage = new Mocha(beverage);
            beverage = new SteamedMilk(beverage);
            Assert.AreEqual("House Blend Coffee, Mocha, Steamed Milk $1.09", beverage.GetDescription() +
                " $" + beverage.Cost());
        }
        #endregion//TestHouseBlend

        #region TestDarkRoast
        [TestMethod]
        public void TestDarkRoast()
        {
            Beverage beverage = new DarkRoast();
            beverage = new Mocha(beverage);
            beverage = new Soy(beverage);
            Assert.AreEqual("Dark Roast Coffee, Mocha, Soy $1.34", beverage.GetDescription() +
                " $" + beverage.Cost());
        }
        #endregion//TestDarkRoast

        #region TestDecaf
        [TestMethod]
        public void TestDecaf()
        {
            Beverage beverage = new Decaf();
            beverage = new Mocha(beverage);
            beverage = new Whip(beverage);
            Assert.AreEqual("Decaf Coffee, Mocha, Whip $1.35", beverage.GetDescription() +
                " $" + beverage.Cost());
        }
        #endregion//TestDecaf
    }
}
