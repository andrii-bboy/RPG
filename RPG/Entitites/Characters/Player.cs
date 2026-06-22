using RPG.Items;
using RPG.Utils;
using System;

namespace RPG.Entitites.Characters
{
    public class Player : Character
    {
        private int _strength = 3;
        private int _agility = 2;
        private int _intelligence = 5;
        private int _endurance = 3;
        private int _gold = 50;
        private int _experience = 0;
        private int _levelcup = 100;
        private double _criticalChance = 0;

        public ProgressBarValue MP { get; set; } = null;
        public Weapon Weapon { get; set; } = null;
        public Armor Armor { get; set; } = null;

        public Player(string name, int level) : base(name, level)
        {
            this._strength = 3;
            this._agility = 2;
            this._endurance = 3;
            this._intelligence = 5;
            this._gold = 50;
            this._levelcup = 100;
            this._experience = 0;

            this.HP = new ProgressBarValue(this._endurance * 10);
            this.MP = new ProgressBarValue(this._intelligence * 5);

            RecalculateStats();
        }

        public int Strength
        {
            get => _strength;
            set => _strength = value;
        }

        public int Agility
        {
            get => _agility;
            set => _agility = value;
        }

        public int Intelligence
        {
            get => _intelligence;
            set => _intelligence = value;
        }

        public int Endurance
        {
            get => _endurance;
            set
            {
                _endurance = value;
                RecalculateStats();
            }
        }

        public int Gold
        {
            get => _gold;
            set => _gold = value;
        }

        public int Experience
        {
            get => _experience;
            set => _experience = value;
        }

        public int LevelCup
        {
            get => _levelcup;
            set => _levelcup = value;
        }

        public double CriticalChance
        {
            get => _criticalChance;
            set => _criticalChance = value;
        }

        public void spendGold(int amount)
        {
            this._gold -= amount;
        }

        public void addGold(int amount)
        {
            this._gold += amount;
        }

        public void addExperience(int amount)
        {
            this._experience += amount;
            while (this._experience >= this._levelcup)
            {
                this._experience -= this._levelcup;
                LevelUp();
            }
        }

        private void LevelUp()
        {
            this._level++;
            this._strength += 2;
            this._endurance += 2;
            this._agility += 1;
            this._intelligence += 3;

            RecalculateStats();

            if (this.HP != null) this.HP.increase(this._endurance * 10);
            if (this.MP != null) this.MP.increase(this._intelligence * 5);

            MessageHelper.LevelUpMessage(this._name, this._level);
        }

        public void RecalculateStats()
        {
            int maxHp = this._endurance * 10;
            int maxMp = this._intelligence * 5;

            if (this.HP != null)
            {
                this.HP.Init(maxHp, this.HP.Value);
            }

            if (this.MP != null)
            {
                this.MP.Init(maxMp, this.MP.Value);
            }
            this._criticalChance = this._agility * 0.5;
        }


        public int CalculateAttackPower()
        {
            int weaponBonus = (Weapon != null) ? Weapon.getDamage() : 0;
            return this._strength + weaponBonus;
        }

        public int CalculateDefense()
        {
            int armorBonus = (Armor != null) ? Armor.getDefense() : 0;
            return this._agility + armorBonus;
        }
    }
}
