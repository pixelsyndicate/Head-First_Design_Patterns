using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using IteratorPatternClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IteratorUnitTests
{
    [TestClass]
    public class WaitressTests
    {
        [TestMethod]
        public void Can_Waitress_Print_Multiple_Menus()
        {
            var waitress = new Waitress(new PancakeHouseMenu(), new DinerMenu(), new CafeMenu());
            waitress.PrintMenu();
        }


        [TestMethod]
        public void Can_Waitress_Print_Array_of_Menus()
        {
            var menuArray = new IMenu[] { new PancakeHouseMenu(), new DinerMenu(), new CafeMenu() };
            var waitress = new Waitress(menuArray);
            waitress.PrintMenus();
        }

    }
}
