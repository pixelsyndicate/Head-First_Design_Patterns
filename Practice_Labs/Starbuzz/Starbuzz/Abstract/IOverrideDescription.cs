namespace Starbuzz.Abstract
{
    public interface IOverrideDescription
    {
        /// <summary>
        ///     BE SURE TO override string GetDescription() to ensure it's feeding from the Beverage Baseclass
        /// </summary>
        /// <returns></returns>
        string GetDescription();
    }
}