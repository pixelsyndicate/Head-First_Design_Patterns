using System;
using IteratorPatternClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IteratorUnitTests
{
    [TestClass]
    public class WaitressTests
    {
        [TestMethod]
        public void Can_I_Iterate_Through_Array()
        {
            var waitress = new Waitress(new PancakeHouseMenu(), new DinerMenu());

        }


        [TestMethod]
        public void Can_I_Iterate_Through_ArrayList()
        {
            var waitress = new Waitress(new PancakeHouseMenu(), new DinerMenu());
        }
    }


    [TestClass]
    public class IteratorImplimenationTests
    {
        [TestMethod]
        public void Can_I_Iterate_Through_Array()
        {
            var dinerMenu = new DinerMenu();
            IIterator dinerIterator = dinerMenu.CreateIterator();
            printMenu(dinerIterator);


        }

        private void printMenu(IIterator iterator)
        {
            while (iterator.HasNext())
            {
                MenuItem menuItem = iterator.Next();
                Console.Write($"{menuItem.GetName}, ");
                Console.Write($"{menuItem.GetPrice} -- ");
                Console.WriteLine($"{menuItem.GetDescription}");
            }

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
