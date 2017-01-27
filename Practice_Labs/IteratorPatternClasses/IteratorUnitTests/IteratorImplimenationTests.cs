using System;
using IteratorPatternClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IteratorUnitTests
{
    [TestClass]
    public class IteratorImplimenationTests
    {

        [TestMethod]
        public void Can_I_Get_MenuIterator_from_Diner()
        {
            var menu = new DinerMenu();
            IIterator menuIterator = menu.CreateIterator();
            Assert.IsNotNull(menuIterator);
            Assert.IsInstanceOfType(menuIterator, typeof(IIterator));
        }
        [TestMethod]
        public void Can_I_Get_MenuIterator_from_PancakeHouse()
        {
            var menu = new PancakeHouseMenu();
            IIterator menuIterator = menu.CreateIterator();
            Assert.IsNotNull(menuIterator);
            Assert.IsInstanceOfType(menuIterator, typeof(IIterator));
        }

        [TestMethod]
        public void Can_I_Get_MenuIterator_from_Cafe()
        {
            var menu = new DinerMenu();
            IIterator menuIterator = menu.CreateIterator();
            Assert.IsNotNull(menuIterator);
            Assert.IsInstanceOfType(menuIterator, typeof(IIterator));
        }

        [TestMethod]
        public void Can_I_Iterate_Through_DinerMenu_Array()
        {
            var menu = new DinerMenu();
            IIterator menuIterator = menu.CreateIterator();
            bool result = printMenu(menuIterator);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Can_I_Iterate_Through_PancakeHouseMenu_ArrayList()
        {
            var menu = new PancakeHouseMenu();
            IIterator menuIterator = menu.CreateIterator();

            bool result = printMenu(menuIterator);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Can_I_Iterate_Through_CafeMenu_HashMap_aka_Dictionary()
        {
            var menu = new CafeMenu();
            IIterator menuIterator = menu.CreateIterator();

            bool result = printMenu(menuIterator);
            Assert.IsTrue(result);
        }

        private bool printMenu(IIterator iterator)
        {
            bool didPrint = false;
            while (iterator.HasNext())
            {
                MenuItem menuItem = iterator.Next();
                // could pass NULL if empty slot in max list.
                if (menuItem != null)
                {
                    didPrint = true;
                    Console.Write($"{menuItem.GetName()}, ");
                    Console.Write($"${menuItem.GetPrice()} -- ");
                    Console.WriteLine($"{menuItem.GetDescription()}");
                }
            }
            return didPrint;
        }


        [TestMethod]
        public void Can_I_Iterate_Through_ArrayList()
        {
            var pancakeHouseMenu = new PancakeHouseMenu();
            IIterator pancakeIterator = pancakeHouseMenu.CreateIterator();
            printMenu(pancakeIterator);
        }
    }
}