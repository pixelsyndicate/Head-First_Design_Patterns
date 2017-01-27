using System.Collections.Generic;
using System.Diagnostics;

namespace IteratorPatternClasses
{
    /// <summary>
    /// one restaurant uses arrays
    /// </summary>
    public class DinerMenu
    {
        private static readonly int MAX_ITEMS = 6;
        private int _numberOfItems = 0;
        private readonly MenuItem[] _menuItems;

        public DinerMenu()
        {
            _menuItems = new MenuItem[MAX_ITEMS];
            // add some
            AddItem("Vegetatarian BLT", "Fakin' Bacon inside", true, 2.99);
            AddItem("Regular BLT", "real pork inside", false, 2.99);
            AddItem("Hotdog", "not sure what's inside", true, 3.45);
            AddItem("Soup of the Day", "a coin flip, really", true, 3.59);
        }

        // we don't need to impliment this anymore because it exposes our 
        // internal implimenation (use of MenuItem[] array)
        public void AddItem(string name, string descr, bool veg, double price)
        {
            var menuItem = new MenuItem(name, descr, veg, price);
            if (_numberOfItems >= MAX_ITEMS)
            {
                Debug.WriteLine("Sorry, menu is full! Can't add item to menu.");
            }
            else
            {
                _menuItems[_numberOfItems] = menuItem;
                _numberOfItems++;
            }
        }

        public IList<MenuItem> GetMenuItems()
        {
            return _menuItems;
        }

        // instead we replace with this factory method, to return our own encapsulation
        // this way the client doesn't need to know how the iteration is implimneted.
        public IIterator CreateIterator()
        {
            // inject the menu items directly into the iterator
            // aka the Hollywood Principle "don't call us, we'll call you"
            return new DinerMenuIterator(_menuItems);
        }

        // other menu methods here depending on the menu being an Array
    }
}