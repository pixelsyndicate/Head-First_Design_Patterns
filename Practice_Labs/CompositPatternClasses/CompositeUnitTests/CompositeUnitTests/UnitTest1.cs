using System;
using CompositePatternClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CompositeUnitTests
{
    [TestClass]
    public class MenuComponentTests
    {
        [TestMethod]
        public void Can_I_Use_Menus_In_Composite_Pattern()
        {
            MenuComponent pancakeHouseMenu = new Menu("PANCAKE HOUSE MENU", "Breakfast");
            MenuComponent dinerMenu = new Menu("DINER MENU", "Lunch");
            MenuComponent cafeMenu = new Menu("CAFE MENU", "Dinner");
            MenuComponent dessertMenu = new Menu("DESSERT MENU", "Dessert of course");

            MenuComponent allMenus = new Menu("ALL MENUS", "All menus combined");

            allMenus.Add(pancakeHouseMenu);
            allMenus.Add(dinerMenu);
            allMenus.Add(cafeMenu);


            // add menu items here
            dinerMenu.Add(new MenuItem("Vegetatarian BLT", "Fakin' Bacon inside", true, 2.99));
            dinerMenu.Add(new MenuItem("Regular BLT", "real pork inside", false, 2.99));
            dinerMenu.Add(new MenuItem("Hotdog", "not sure what's inside", true, 3.45));
            dinerMenu.Add(new MenuItem("Soup of the Day", "a coin flip, really", true, 3.59));

            cafeMenu.Add(new MenuItem("Veggie Burger and Air Fries", "Not a whole lot of anything", true, 2.99));
            cafeMenu.Add(new MenuItem("Burrito", "real mexicans inside", false, 2.99));
            cafeMenu.Add(new MenuItem("Soup of the Day", "a coin flip, really", true, 3.59));

            pancakeHouseMenu.Add(new MenuItem("Big Breakfast", "some good stuff inside", true, 2.99));
            pancakeHouseMenu.Add(new MenuItem("Regular Breakfast", "some basic stuff inside", false, 2.99));
            pancakeHouseMenu.Add(new MenuItem("Blueberry Pancakes", "a stack of blue goodness", true, 3.45));
            pancakeHouseMenu.Add(new MenuItem("Waffles", "not the belgian kind tho", true, 3.59));

            // add to the dinner menu a dessert menu item
            dinerMenu.Add(dessertMenu);

            dessertMenu.Add(new MenuItem("Apple Pie", "Apple pie with flaky crust, topped with vanilla icecream", true, 1.56));

            Waitress waitress = new Waitress(allMenus);

            waitress.PrintMenus();
        }
    }
}