namespace Starbuzz.Abstract
{
    /// <summary>
    ///     Having an abstract, with a superclass as its base 
    ///     allows us to use HAS-A 'Beverage' (in private, injectable field) within the BeverageDecorator concrete,
    ///     rather than being forced to implement any portion of the baseclass; 
    ///     while still being a TYPE OF in as far as run-time cares.
    /// </summary>
    public abstract class BeverageDecorator : Beverage
    {
        public virtual bool IsDairy()
        {
            return false;
        }
    }
}