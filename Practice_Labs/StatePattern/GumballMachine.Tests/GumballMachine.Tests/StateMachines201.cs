using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StateMachine;

namespace GumballMachine.Tests
{
    /// <summary>
    /// This series of tests are for the gumball machine that has a 10% chance of winning a second gumball.
    /// </summary>
    [TestClass]
    public class StateMachines201
    {
        [TestMethod]
        public void Can_I_Win_A_Gumball()
        {
            int startInventory = 20;
            var gbm = new GumballMachineContext(startInventory);
            Assert.IsNotNull(gbm);
            var inventoryCount = gbm.Inventory;
            Assert.AreEqual(startInventory, inventoryCount);
            Debug.WriteLine($"The gumball machine has {gbm} gumballs.");

            while (gbm.Inventory > 0)
            {
                gbm.InsertQuarter();
                gbm.TurnCrank();
                Debug.WriteLine($"The gumball machine has {gbm} gumballs.");
            }
            //gbm.InsertQuarter();
            //gbm.TurnCrank(); // -1 or -2 if is a winner
            //Debug.WriteLine($"The gumball machine has {gbm} gumballs.");
        }

        [TestMethod]
        public void Can_I_Get_Current_Inventory_Count()
        {
            int startInventory = 5;
            var gbm = new GumballMachineContext(startInventory);
            Assert.IsNotNull(gbm);
            var inventoryCount = 0;
            Assert.IsTrue(int.TryParse(gbm.ToString(), out inventoryCount));
            Assert.AreEqual(gbm.Inventory, startInventory);
            Debug.WriteLine($"The gumball machine has {gbm} gumballs.");
        }


        [TestMethod]
        public void Can_I_Handle_Sold_Out()
        {
            int startInventory = 1;
            var gbm = new StateMachine.GumballMachineContext(startInventory);
            Assert.IsNotNull(gbm);
            Debug.WriteLine($"The gumball machine has {gbm} gumballs.");
            gbm.InsertQuarter();
            gbm.TurnCrank(); // -1
            Assert.AreEqual(gbm.Inventory, startInventory - 1);
            Debug.WriteLine($"The gumball machine has {gbm} gumballs.");

            // try to put in a quarter
            gbm.InsertQuarter();
            gbm.TurnCrank();
            gbm.EjectQuarter();
        }

        [TestMethod]
        public void Can_I_Buy_A_Gumball()
        {
            int startInventory = 5;
            var gbm = new StateMachine.GumballMachineContext(startInventory);
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
            var gbm = new GumballMachineOld(startInventory);
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
            var gbm = new GumballMachineOld(startInventory);
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
