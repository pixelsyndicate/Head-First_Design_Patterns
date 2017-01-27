using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CompositePatternClasses
{
    // MenuComponent interface for both MenuItem and Menu. Astract class so we can provide default implimentations
    public abstract class MenuComponent
    {
        #region OPERATION METHODS 
        public virtual string GetName() { throw new NotSupportedException(); }

        public virtual string GetDescription() { throw new NotSupportedException(); }

        public virtual bool IsVegetarian() { throw new NotSupportedException(); }

        public virtual double GetPrice() { throw new NotSupportedException(); }

        public virtual void Print() { throw new NotSupportedException("Implement MenuComponent.Print"); }
        #endregion

        #region COMPOSITE METHODS
        public virtual void Add(MenuComponent cmp) { throw new NotSupportedException(); }

        public virtual void Remove(MenuComponent cmp) { throw new NotSupportedException("Implement MenuComponent.Remove"); }

        public virtual MenuComponent GetChild(int index) { throw new NotSupportedException("Implement MenuComponent.GetChild"); }
        #endregion
    }

    public class MenuItem : MenuComponent
    {
        string _name; string _description; bool _vegetarian; double _price;

        public MenuItem(string name, string description, bool vegetarian, double price)
        {
            _name = name;
            _description = description;
            _vegetarian = vegetarian;
            _price = price;
        }

        #region SIMILAR GETTERS AS USED IN MENUITEM OF ITERATORPATTERNCLASSES
        public override string GetName() { return _name; }
        public override string GetDescription() { return _description; }
        public override bool IsVegetarian() { return _vegetarian; }
        #endregion

        public override void Print()
        {
            Console.Write(" " + GetName());
            if (IsVegetarian())
                Console.Write(" (v) ");
            Console.Write(", " + GetPrice());
            Console.WriteLine("     -- " + GetDescription());
        }

        public override double GetPrice() { return _price; }

    }

    public class Menu : MenuComponent
    {
        private IList<MenuComponent> _menuComponents = new List<MenuComponent>();
        string _name; string _description;

        public Menu(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public override string GetName() { return _name; }
        public override string GetDescription() { return _description; }

        public override void Print()
        {
            #region PRINT THIS MENU
            Console.Write("\n" + GetName());
            Console.WriteLine(", " + GetDescription());
            Console.WriteLine("----------------------------");
            #endregion

            #region AND ALL CHILD MENUS
            var iterator = _menuComponents.GetEnumerator();
            string spacer = " --- ";
            while (iterator.MoveNext())
            {
                MenuComponent menuComponent = iterator.Current;
                menuComponent.Print();
            }

            #endregion
        }

        public override void Add(MenuComponent cmp) { _menuComponents.Add(cmp); }

        public override void Remove(MenuComponent cmp) { _menuComponents.Remove(cmp); }

        public override MenuComponent GetChild(int index) { return _menuComponents[index]; }
    }
}
