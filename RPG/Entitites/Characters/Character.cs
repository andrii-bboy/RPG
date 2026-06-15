using RPG.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Entitites.Characters
{
    public abstract class Character
    {
        protected string _name = "";
        protected int _level = 1;
        public ProgressBarValue HP;

        public Character(string name, int level)
        {
            this._name = name;
            this._level = level;
        }
        protected void createHPValue(int hp)
        {
            HP = new ProgressBarValue(hp);
        }
        public string getName() => _name;
        public int getLevel() => _level;
        public void setLevel(int level)
        {
            this._level = level;
        }

    }
}
