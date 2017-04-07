using System;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GumballMachine.Tests
{
    /// <summary>
    /// Summary description for StateMachines101
    /// </summary>
    [TestClass]
    public class StateMachines101
    {
        public StateMachines101()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void Can_I_Get_Current_Inventory_Count()
        {
            int startInventory = 5;
            var gbm = new GumballMachine(startInventory);
            Assert.IsNotNull(gbm);
            var inventoryCount = 0;
            Assert.IsTrue(int.TryParse(gbm.ToString(), out inventoryCount));
            Assert.AreEqual(inventoryCount, startInventory);
            Debug.WriteLine($"The gumball machine has {gbm} gumballs.");
        }


        [TestMethod]
        public void Can_I_Buy_A_Gumball()
        {
            int startInventory = 5;
            var gbm = new GumballMachine(startInventory);
            Assert.IsNotNull(gbm);
            var inventoryCount = 0;
            Assert.IsTrue(int.TryParse(gbm.ToString(), out inventoryCount));
            Debug.WriteLine($"The gumball machine has {gbm} gumballs.");
            gbm.InsertQuarter();
            gbm.TurnCrank(); // -1
            Assert.IsTrue(int.TryParse(gbm.ToString(), out inventoryCount));
            Assert.AreEqual(inventoryCount, startInventory - 1);
            Debug.WriteLine($"The gumball machine has {gbm} gumballs.");
        }


        [TestMethod]
        public void Can_I_Prevent_Free_Gumball()
        {
            int startInventory = 5;
            var gbm = new GumballMachine(startInventory);
            Assert.IsNotNull(gbm);
            var inventoryCount = 0;
            Assert.IsTrue(int.TryParse(gbm.ToString(), out inventoryCount));
            Debug.WriteLine($"The gumball machine has {gbm} gumballs.");
            gbm.InsertQuarter();
            gbm.EjectQuarter();
            gbm.TurnCrank();
            Assert.IsTrue(int.TryParse(gbm.ToString(), out inventoryCount));
            Assert.AreEqual(inventoryCount, startInventory);
            Debug.WriteLine($"The gumball machine has {gbm} gumballs.");
        }


        [TestMethod]
        public void Can_I_Empty_The_Machine()
        {
            int startInventory = 3;
            var gbm = new GumballMachine(startInventory);
            Assert.IsNotNull(gbm);
            var inventoryCount = 0;
            Assert.IsTrue(int.TryParse(gbm.ToString(), out inventoryCount));
            Debug.WriteLine($"The gumball machine has {gbm} gumballs.");

            gbm.InsertQuarter();
            gbm.InsertQuarter();
            gbm.TurnCrank(); // -1
            gbm.InsertQuarter();
            gbm.TurnCrank(); // -1
            gbm.InsertQuarter();
            gbm.TurnCrank(); // -1

            gbm.InsertQuarter();
            gbm.TurnCrank(); // -1

            Assert.IsTrue(int.TryParse(gbm.ToString(), out inventoryCount));
            Assert.AreEqual(inventoryCount, startInventory - 3);
            Debug.WriteLine($"The gumball machine has {gbm} gumballs.");
        }
    }
}
