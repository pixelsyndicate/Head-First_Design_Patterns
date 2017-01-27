using System.Collections.Generic;

namespace IteratorPatternClasses
{
    /// <summary>
    /// one restaurant uses arraylists
    /// </summary>
    public class PancakeHouseMenu
    {
        private IList<MenuItem> _menuItems;

        public PancakeHouseMenu()
        {
            _menuItems = new List<MenuItem>();
            // add some
            AddItem("Big Breakfast", "some good stuff inside", true, 2.99);
            AddItem("Regular Breakfast", "some basic stuff inside", false, 2.99);
            AddItem("Blueberry Pancakes", "a stack of blue goodness", true, 3.45);
            AddItem("Waffles", "not the belgian kind tho", true, 3.59);
        }

        public void AddItem(string name, string descr, bool veg, double price)
        {
            var menuItem = new MenuItem(name, descr, veg, price);
            _menuItems.Add(menuItem);
        }

        // we don't need to impliment this anymore because it exposes our 
        // internal implimenation ( use of IList<T> )
        public IList<MenuItem> GetMenuItems()
        {
            return _menuItems;
        }

        // instead we replace with this factory method, to return our own encapsulation
        // this way the client doesn't need to know how the iteration is implimneted.
        /// <summary>
        /// Creates a DinerMenuIterator object that 
        /// </summary>
        /// <returns></returns>
        public IIterator CreateIterator()
        {
            // inject the menu items directly into the iterator
            // aka the Hollywood Principle "don't call us, we'll call you"
            return new DinerMenuIterator(_menuItems);
        }

        // other menu methods here depending on the menu being an ArrayList (IList)
    }
}