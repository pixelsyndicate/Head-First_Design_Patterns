using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadFirstDesignPatterns.Strategy.Character;

namespace UnitTestProject
{
    [TestClass]
    public class StrategyWeaponFixture
    {
        #region TestKingWeapon
        [TestMethod]
        public void TestKingWeapon()
        {
            HeadFirstDesignPatterns.Strategy.Character.King KingWeapon = new King();
            Assert.AreEqual("I swing at thee with this sword!", KingWeapon.Fight());
        }
        #endregion//TestKingWeapon

        #region TestQueenWeapon
        [TestMethod]
        public void TestQueenWeapon()
        {
            HeadFirstDesignPatterns.Strategy.Character.Queen QueenWeapon = new Queen();
            Assert.AreEqual("I will knife thee, nave!", QueenWeapon.Fight());
        }
        #endregion//TestQueenWeapon

        #region TestKnightWeapon
        [TestMethod]
        public void TestKnightWeapon()
        {
            HeadFirstDesignPatterns.Strategy.Character.Knight KnightWeapon = new Knight();
            Assert.AreEqual("I shot my arrow at thee!", KnightWeapon.Fight());
        }
        #endregion//TestKnightWeapon

        #region TestTrollWeapon
        [TestMethod]
        public void TestTrollWeapon()
        {
            HeadFirstDesignPatterns.Strategy.Character.Troll TrollWeapon = new Troll();
            Assert.AreEqual("I will chop thine head off!", TrollWeapon.Fight());
        }
        #endregion//TestTrollWeapon
    }
}
