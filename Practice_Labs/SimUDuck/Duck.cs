using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimUDuck
{
    abstract class Duck
    {
        public virtual void Quack()
        {
            // quack
        }

        public void Swim()
        {
            // swim
        }

        public abstract void Display();

        public void Fly()
        {
            // fly
        }
    }
}
