using System;
using RPG.GameServices;
using RPG.Utils;

namespace RPG.Entitites.Characters.Enemies
{
    public class Enemy : Character
    {
        private int _attack;
        private int _defence;
        private int _rewardGold;
        private int _rewardXp;
        private string _specialAbility;

        public string SpecialAbility => _specialAbility;

        public Enemy(string name, int level) : base(name, level)
        {
            this._attack = level * 3 + CustomRandomizer.generateNumber(1, 2);
            this._defence = level * 1;

            this._rewardGold = level * 12 + CustomRandomizer.generateNumber(1, 10);
            this._rewardXp = level * 20;
            this._specialAbility = "None";

            this.createHPValue(level * 15 + 10);
        }

        public int getAttack() => this._attack;
        public int getDefence() => this._defence;
        public int getRewardGold() => this._rewardGold;
        public int getRewardXp() => this._rewardXp;
        public static Enemy Generate(int playerLevel)
        {
            int enemyLevel = Math.Max(1, playerLevel + CustomRandomizer.generateNumber(-1, 1));

            
            string[] coolNames = { "Serious Rooster", "Mad Crow", "Iron Racoon", "Alpha Wolf" };

            int randomIndex = CustomRandomizer.generateNumber(0, coolNames.Length - 1);
            string finalName = coolNames[randomIndex];

            return new Enemy(finalName, enemyLevel);
        }
    }
}