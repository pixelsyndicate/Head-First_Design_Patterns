using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadFirstDesignPatterns.Singleton.InterestRate;

namespace UnitTestProject
{
    [TestClass]
    public class SingletonRateFixture
    {
        #region TestCurrentRate
        [TestMethod]
        public void TestCurrentRate()
        {
            RateImplementation theRate = new RateImplementation();
            RateImplementation theRate2 = new RateImplementation();
            Assert.AreEqual(.015, theRate.GetRate());
            Assert.AreEqual(.015, theRate2.GetRate());
        }
        #endregion//TestCurrentRate
    }
}
