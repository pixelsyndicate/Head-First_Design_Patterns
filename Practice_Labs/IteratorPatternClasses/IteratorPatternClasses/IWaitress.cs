namespace IteratorPatternClasses
{
    /// <summary>
    /// the menu printer app, that can't be bothered to impliment each type of collection 
    /// object used in the various menus. (array, arraylist, hashset, etc)
    /// </summary>
    public interface IWaitress
    {
        void PrintMenu();
        void PrintBreakfastMenu();
        void PrintLunchMenu();
        void PrintVegetarianMenu();
        bool IsItemVegitarian(string name);
    }
}