using System;
using System.Collections.Generic;
using RPG.Items;
using RPG.Utils;

namespace RPG.GameServices
{
    public class ArmorGenerator
    {
        private string[] _names = new string[]
        {
            "Old Cloak", "Leather Vest", "Reinforced ChestPlate", "Golden Armor",
            "Chainmail Shirt", "Scale Armor", "Iron ChestPlate",
            "Steel Plate", "Guardian Armor", "Dragon Scale Armor"
        };

        public Armor createOne(int playerLevel)
        {
            string name = _names[CustomRandomizer.generateNumber(0, _names.Length - 1)];
            int defenseBonus = playerLevel * 2 + CustomRandomizer.generateNumber(1, 4);
            int price = defenseBonus * 20 + CustomRandomizer.generateNumber(10, 25);
            return new Armor(name + $" +{playerLevel}", price, defenseBonus);
        }

        public List<Armor> createMany(int count, int playerLevel)
        {
            List<Armor> list = new List<Armor>();
            for (int i = 0; i < count; i++)
            {
                list.Add(createOne(playerLevel));
            }
            return list;
        }
    }
}
