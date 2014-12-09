using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Starbuzz
{
    public abstract class Beverage
    {
        public string Description = "Unknown Beverage";

        public virtual string GetDescription()
        {
            return Description;
        }

        // cost will be required to be implimented in the type of beverage
        public abstract double Cost();
    }


}
