using System;

namespace RPG.Utils
{
    public class ProgressBarValue
    {
        private int _minimum = 0;
        private int _maximum = 100;
        private int _value = 0;

        public int Value
        {
            get => this._value;
            set
            {
                this._value = value;
                if (this._value > this._maximum) this._value = this._maximum;
                if (this._value < this._minimum) this._value = this._minimum;
            }
        }

        public int Max
        {
            get => this._maximum;
            set
            {
                this._maximum = value;
                if (this._value > this._maximum) this._value = this._maximum;
            }
        }

        public ProgressBarValue(int max, int min = 0)
        {
            this._maximum = max;
            this._value = max;
        }

        public void Init(int max, int current)
        {
            this._maximum = max;
            this.Value = current;
        }

        public bool decrease(int amount)
        {
            if (this._value - amount <= this._minimum)
            {
                this._value = this._minimum;
                return true;
            }
            else
            {
                this._value -= amount;
                return false;
            }
        }

        public void increase(int amount)
        {
            this.Value += amount;
        }
    }
}
