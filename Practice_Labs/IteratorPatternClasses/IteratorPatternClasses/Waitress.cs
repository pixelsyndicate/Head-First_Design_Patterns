using System;

namespace IteratorPatternClasses
{
    public class Waitress : IWaitress
    {
        private PancakeHouseMenu _pancakeHouseMenu;
        private DinerMenu _dinerMenu;

        public Waitress(PancakeHouseMenu pancakeHouseMenu, DinerMenu dinerMenu)
        {
            _pancakeHouseMenu = pancakeHouseMenu;
            _dinerMenu = dinerMenu;
        }


        public void PrintMenu()
        {
            IIterator pancakeIterator = _pancakeHouseMenu.CreateIterator();
            IIterator dinerIterator = _dinerMenu.CreateIterator();

            Console.WriteLine("MENU \n ----- \nBREAKFAST");
            printMenu(pancakeIterator);
            Console.WriteLine("\nLUNCH");
            Console.WriteLine();
            printMenu(dinerIterator);

        }

        private void printMenu(IIterator iterator)
        {
            while (iterator.HasNext())
            {
                MenuItem menuItem = iterator.Next();
                if (menuItem != null)
                {
                    Console.Write($"{menuItem.GetName}, ");
                    Console.Write($"{menuItem.GetPrice} -- ");
                    Console.WriteLine($"{menuItem.GetDescription}");
                }
            }
        }

        public void PrintBreakfastMenu() { }

        public void PrintLunchMenu() { }

        public void PrintVegetarianMenu() { }

        public bool IsItemVegitarian(string name)
        {
            return false;
        }
    }
}