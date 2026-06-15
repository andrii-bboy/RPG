using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RPG.Utils
{
    public class ProgressBarValue
    {
        private int _minimum = 0;
        private int _maximum = 100;
        private int _value = 0;
        public int Value => this._value;
        public ProgressBarValue(int max, int min = 0)
        {
            Init(max, min);
        }
        public void Init(int max, int min = 0) 
        {
            this._minimum = min;
            this._maximum = this._value = max;
        }

        public void increase(int value)
        {
            if (this._value + value > this._maximum)
            {
                this._value = this._maximum;
            }
            else
            {
                this._value += value;
            }
        }
        public bool decrease(int Value)
        {
            if (this._value - Value <= this._minimum)
            {
                this._value = this._minimum;
                return false;
            }
            else
            {
                this._value -= Value;
                return true;
            }
        }
    }
}
