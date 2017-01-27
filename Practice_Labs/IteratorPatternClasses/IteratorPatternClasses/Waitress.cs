using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorPatternClasses
{
    public class Waitress : IWaitress
    {
        // solve the problem with having to code everytime a new menu is added. 
        private IEnumerable<IMenu> _menus;

        private readonly IMenu _pancakeHouseMenu;
        private readonly IMenu _dinerMenu;
        private readonly IMenu _cafeMenu;


        public Waitress(IMenu pancakeHouseMenu, IMenu dinerMenu)
        {
            _pancakeHouseMenu = pancakeHouseMenu;
            _dinerMenu = dinerMenu;
        }

        public Waitress(PancakeHouseMenu pancakeHouseMenu, DinerMenu dinerMenu, CafeMenu cafeMenu)
        {
            _pancakeHouseMenu = pancakeHouseMenu;
            _dinerMenu = dinerMenu;
            _cafeMenu = cafeMenu;
        }

        // solve the problem with having to code everytime a new menu is added. 
        public Waitress(IMenu[] menus)
        {
            _menus = menus;
        }


        public void PrintMenus()
        {
            IEnumerator<IMenu> menuIterator = _menus.GetEnumerator();
            while (menuIterator.MoveNext())
            {
                var menu = menuIterator.Current;
                printMenu(menu.CreateIterator());
            }
        }

        public void PrintMenu()
        {
            IIterator pancakeIterator = _pancakeHouseMenu.CreateIterator();
            IIterator dinerIterator = _dinerMenu.CreateIterator();
            IIterator cafeIterator = _cafeMenu.CreateIterator();

            Console.WriteLine("MENU \n ----- \nBREAKFAST");
            printMenu(pancakeIterator);
            Console.WriteLine("\nLUNCH");
            printMenu(dinerIterator);
            Console.WriteLine("\nDINNER");
            printMenu(cafeIterator);
        }

        private void printMenu(IIterator iterator)
        {
            while (iterator.HasNext())
            {
                MenuItem menuItem = iterator.Next();
                Console.Write($"{menuItem.GetName()}, ");
                Console.Write($"{menuItem.GetPrice()} -- ");
                Console.WriteLine($"{menuItem.GetDescription()}");
            }
        }

        public void PrintBreakfastMenu()
        {
            IIterator pancakeIterator = _pancakeHouseMenu.CreateIterator();
            Console.WriteLine("MENU \n ----- \nBREAKFAST");
            printMenu(pancakeIterator);
        }

        public void PrintLunchMenu()
        {
            IIterator dinerIterator = _dinerMenu.CreateIterator();
            Console.WriteLine("\nLUNCH");
            printMenu(dinerIterator);
        }

        public void PrintVegetarianMenu()
        {
        }

        public bool IsItemVegitarian(string name)
        {
            throw new NotImplementedException("Need to impliment IsItemVegitarian");

        }
    }
}