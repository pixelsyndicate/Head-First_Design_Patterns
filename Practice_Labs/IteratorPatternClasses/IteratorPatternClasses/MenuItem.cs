namespace IteratorPatternClasses
{
    /// <summary>
    /// agreed upon menu item for a couple restaurants
    /// </summary>
    public class MenuItem
    {
        private readonly string _name;
        private readonly string _description;
        private readonly bool _vegetarian;
        private readonly double _price;

        public MenuItem(string name, string description, bool vegetarian, double price)
        {
            this._name = name;
            this._description = description;
            this._vegetarian = vegetarian;
            this._price = price;
        }


        public string GetName
        {
            get { return _name; }
        }

        public string GetDescription
        {
            get { return _description; }
        }

        public bool IsVegetarian
        {
            get { return _vegetarian; }
        }

        public double GetPrice
        {
            get { return _price; }
        }
    }
}