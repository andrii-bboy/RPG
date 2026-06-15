using System;
using System.Collections.Generic;
using RPG.Items;
using RPG.Utils;

namespace RPG.GameServices
{
    public class WeaponGenerator
    {
        private string[] _names = new string[]
        {
            "Rusty Dagger", "Bronze Sword", "Iron Mace", "Steel Sword",
            "Ancient Spear", "Assassins Blade", "Dwarf Hammer",
            "Blessed Rapier", "Demonic Cleaver", "Mythic Knight Sword"
        };

        public Weapon createOne(int playerLevel)
        {
            string name = _names[CustomRandomizer.generateNumber(0, _names.Length - 1)];
            int attackBonus = playerLevel * 3 + CustomRandomizer.generateNumber(1, 5);
            int price = attackBonus * 15 + CustomRandomizer.generateNumber(10, 30);
            return new Weapon(name + $" +{playerLevel}", price, attackBonus);
        }

        public List<Weapon> createMany(int count, int playerLevel)
        {
            List<Weapon> list = new List<Weapon>();
            for (int i = 0; i < count; i++)
            {
                list.Add(createOne(playerLevel));
            }
            return list;
        }
    }
}

