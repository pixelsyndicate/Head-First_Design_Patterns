using System.Collections.Generic;
using System.Linq;

namespace IteratorPatternClasses
{
    public class CafeMenu : IMenu
    {
        // create a similiar collection to a Java HasMap<string,MenuItem>
        Dictionary<string, MenuItem> _menuItems = new Dictionary<string, MenuItem>();

        public CafeMenu()
        {
            AddItem("Veggie Burger and Air Fries", "Not a whole lot of anything", true, 2.99);
            AddItem("Burrito", "real mexicans inside", false, 2.99);
            AddItem("Soup of the Day", "a coin flip, really", true, 3.59);
        }

        public void AddItem(string name, string descr, bool veg, double price)
        {
            var menuItem = new MenuItem(name, descr, veg, price);
            _menuItems.Add(menuItem.GetName(), menuItem);
        }

        public IIterator CreateIterator()
        {
            return new CafeMenuIterator(_menuItems.Values);
        }
    }

    public class CafeMenuIterator : IIterator
    {
        private readonly MenuItem[] _items;
        private int _position = 0;

        public CafeMenuIterator(IEnumerable<MenuItem> menuItems)
        {
            _items = menuItems.ToArray();
        }

        /// <summary>
        /// lets you know if there is another position in this that hasn't been gotten through NEXT()
        /// </summary>
        /// <returns></returns>
        public bool HasNext()
        {
            return (_position >= _items.Length || _items[_position] == null) == false;
        }

        /// <summary>
        /// Return the next MenuItem that hasn't yet been gotten.
        /// </summary>
        /// <returns></returns>
        public MenuItem Next()
        {
            MenuItem menuItem = _items[_position];
            _position++;
            return menuItem;
        }
    }
}