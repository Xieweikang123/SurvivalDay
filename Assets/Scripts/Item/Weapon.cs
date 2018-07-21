using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Item
{
   public  class Weapon :ItemBase
    {
        public int Damage;
        public enum WeaponType
        {
            MeleeWapon,
            RangedWeapon,
            Tool

        }
    }
}
