using System.Globalization;
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
            waitress.PrintMenu();
        }


        [TestMethod]
        public void Can_I_Iterate_Through_ArrayList()
        {
            var waitress = new Waitress(new PancakeHouseMenu(), new DinerMenu());
        }
    }
}
