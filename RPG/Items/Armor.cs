using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items
{
    public class Armor : Item
    {
        public Armor(string name, int price, int defense) : base(name, price, defense)
        {
        }
        public int getDefense() => this._value;

    }
}
