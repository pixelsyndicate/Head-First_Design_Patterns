using System.Collections.Generic;

namespace IteratorPatternClasses
{
    public interface IMenu
    {
      //  IList<MenuItem> GetMenuItems();
        IIterator CreateIterator();
    }
}