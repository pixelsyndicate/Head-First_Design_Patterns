using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadFirstDesignPatterns.Adapter.Birds;

namespace UnitTestProject
{
    [TestClass]
    public class AdapterBirdFixture
    {
        
        [TestMethod]
        public void TestMallardDuck()
        {
            Duck mallard = new MallardDuck();
            Assert.AreEqual("Quack", mallard.Quack());
            Assert.AreEqual("I'm flying", mallard.Fly());
        }

        [TestMethod]
        public void TestWildTurkey()
        {
            Turkey wildTurkey = new WildTurkey();
            Assert.AreEqual("Gooble, gooble", wildTurkey.Gobble());
            Assert.AreEqual("I'm flying a short distance", wildTurkey.Fly());
        }

        [TestMethod]
        public void TestTurkeyAdapter()
        {
            Turkey wildTurkey = new WildTurkey();
            Duck turkeyAdapter = new TurkeyAdapter(wildTurkey);

            Assert.AreEqual("Gooble, gooble", turkeyAdapter.Quack());
            Assert.AreEqual("I'm flying a short distance\n" +
                "I'm flying a short distance\n" +
                "I'm flying a short distance\n" +
                "I'm flying a short distance\n" +
                "I'm flying a short distance\n", turkeyAdapter.Fly());
        }

        [TestMethod]
        public void TestDuckAdapter()
        {
            Duck mallard = new MallardDuck();
            Turkey duckAdapter = new DuckAdapter(mallard);

            Assert.AreEqual("Quack", duckAdapter.Gobble());
            Assert.AreEqual("I'm flying", duckAdapter.Fly());
        }

    }
}
