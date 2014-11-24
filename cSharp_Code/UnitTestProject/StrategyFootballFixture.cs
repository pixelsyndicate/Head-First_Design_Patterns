using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadFirstDesignPatterns.Strategy.Football;

namespace UnitTestProject
{
    [TestClass]
    public class StrategyFootballFixture
    {
        #region TestPullingGuard
        [TestMethod]
        public void TestPullingGuard()
        {
            Guard pullingGuard = new Guard();
            Assert.AreEqual("I am pulling to block", pullingGuard.Pattern());
        }
        #endregion//TestPullingGuard

        #region TestWideReceiver
        [TestMethod]
        public void TestWideReceiver()
        {
            WideReceiver widereceiverPassPattern = new WideReceiver();
            Assert.AreEqual("I am running a banana pass pattern", widereceiverPassPattern.Pattern());
        }
        #endregion//TestWideReceiver

        #region TestRunningBack
        [TestMethod]
        public void TestRunningBack()
        {
            RunningBack runneringBackPattern = new RunningBack();
            Assert.AreEqual("I am blocking any rushers that the line does not get", runneringBackPattern.Pattern());
        }
        #endregion//TestRunningBack
    }
}
