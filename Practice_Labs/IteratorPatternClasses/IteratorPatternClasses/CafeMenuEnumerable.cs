using System.Collections.Generic;
using System.Linq;

namespace IteratorPatternClasses
{
    public class CafeMenuEnumerable : IIterator
    {
        private readonly MenuItem[] _items;
        private int _position = 0;

        public CafeMenuEnumerable(IEnumerable<MenuItem> menuItems)
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