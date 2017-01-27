using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IteratorPatternClasses;

namespace CompositePatternClasses
{
    // much smaller waitress now, since the MenuComponent handles iteration where needed
    public class Waitress
    {
        // solve the problem with having to code everytime a new menu is added. 
        private MenuComponent _menus;


        // solve the problem with having to code everytime a new menu is added. 
        public Waitress(MenuComponent allMenus)
        {
            _menus = allMenus;
        }

        public void PrintMenus()
        {
            _menus.Print();
        }
    }
}
