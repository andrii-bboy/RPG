using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items
{
    public class Weapon : Item
    {
        public Weapon(string name, int price, int damage) : base(name, price, damage)
        {
        }
        public int getDamage() => this._value;

    }
}
