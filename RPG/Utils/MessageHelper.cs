using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPG.Utils
{
    internal class MessageHelper
    {
        public static void LevelUpMessage(string name, int level)
        {
            MessageBox.Show($"Congrats {name}! You have reached level {level}!", "Level Up", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
