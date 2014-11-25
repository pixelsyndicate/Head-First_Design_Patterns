using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPuzzleChapterOne
{
    public class KnifeBehavior : IWeaponBehavior
    {
        public void useWeapon()
        {
            // impliments cutting with a knife
        }
    }

    public class BowAndArrowBehavior : IWeaponBehavior
    {
        public void useWeapon()
        {
            // implements shooting an arrow with a bow
        }
    }

    public class AxeBehavior : IWeaponBehavior
    {
        public void useWeapon()
        {
            // impliments chopping with an axe
        }
    }
    public class SwordBehavior : IWeaponBehavior
    {
        public void useWeapon()
        {
            // impliments swinging with a sword
        }
    }

}
