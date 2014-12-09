namespace Starbuzz
{


    /// <summary>
    /// Summary description for CondimentDecorator.
    /// </summary>
    public abstract class BeverageDecorator : Beverage
    {

        // NOTE: if you follow the book example and make this ABSTRACT, it will
        // not pass back referece to the BEVERAGE baseclass.
        // public abstract  string GetDescription();
    }

}