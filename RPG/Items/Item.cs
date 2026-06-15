using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Items
{
    public abstract class Item
    {
        protected int id;
        private static int autoInc = 1;
        protected string _name;
        protected int _price;
        protected int _value;

        public Item(string name, int price, int value)
        {
            this.id = autoInc++;
            this._name = name;
            this._price = price;
            this._value = value;
        }
        public string Name
        {
            get { return _name; }
            set {
                if (value.Length >= 3)
                {
                    this._name = value;
                }
            }
        }
        public string getName() => _name;
        public void setName(string name)
        {
            if (name.Length >= 3)
            {
                this._name = name;
            }
        }
        
        public int getPrice()
        {
            return _price;
        }
        public int setPrice(int price)
        {
            if (price > 0)
            {
                this._price = price;
            }
            return _price;
        }
        public int getId()
        {
            return id;
        }
    }
}
