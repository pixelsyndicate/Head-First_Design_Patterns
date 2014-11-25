using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPuzzleChapterOne
{
    public abstract class Character
    {
        private  IWeaponBehavior _weapon;

        public virtual void SetWeapon(IWeaponBehavior w)
        {
            this._weapon = w;
        }

        public virtual void Fight()
        {
            var myWeaponType = _weapon.GetType().ToString();
            Console.WriteLine("I use my " + myWeaponType.Replace("DesignPuzzleChapterOne.","'").Replace("Behavior","'"));
        }
        
    }
}
