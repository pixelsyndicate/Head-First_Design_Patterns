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
            _name = name;
            _description = description;
            _vegetarian = vegetarian;
            _price = price;
        }

        public string GetName() => _name;

        public string GetDescription() => _description;

        public bool IsVegetarian() => _vegetarian;

        public double GetPrice() => _price;
    }
}