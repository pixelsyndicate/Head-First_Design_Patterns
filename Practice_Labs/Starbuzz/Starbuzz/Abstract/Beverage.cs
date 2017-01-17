namespace Starbuzz.Abstract
{
    public abstract class Beverage
    {
        //TODO: surprise! client added sizes and wants it to be incorporated into the pricing.
        public enum Size
        {
            Tall,
            Grande,
            Venti
        }

        #region FIELDS

        public string Description = "Unknown Beverage";
        #endregion

        #region PROPERTIES


        public Size GetSize { get; private set; } = Size.Tall;

        #endregion




        //    We want any beverage type to return a chain of potentials.
        // 1) the abstract base
        // 2) the concrete 
        // 3) the decorator concrete 
        // So mark this as a virtual so that there is a default implimentation, but it can be overridden
        /// <returns>Return the description of the implimentation including any decorator implimentations</returns>
        public virtual string GetDescription()
        {
            return Description;
        }

        // As an abstract method, it doesn't implement here, but places demands on the type-of beverage to impliment cost
        /// <summary>
        ///     Return the cost of the implimentation
        /// </summary>
        /// <returns></returns>
        public abstract double Cost();

        public void SetSize(Size size)
        {
            GetSize = size;
        }
    }
}