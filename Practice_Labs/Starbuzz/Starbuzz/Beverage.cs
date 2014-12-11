using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbuzz
{
    public abstract class Beverage
    {

        // surprise! client added sizes and wants it to be incorporated into the pricing.
        public enum Size {Tall, Grande, Venti }
        private Size _size = Size.Tall;
        public void SetSize(Size size)
        {
            this._size = size;
        }
        public Size GetSize()
        {
            return this._size;
        }

        public string Description = "Unknown Beverage";

        public virtual string GetDescription()
        {
            return Description;
        }

        // cost will be required to be implimented in the type of beverage
        public abstract double Cost();
    }


}
