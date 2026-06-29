using RPG.Entitites.Characters;
using RPG.Items;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace RPG.Forms
{
    public partial class CharacterSelectionForm : Form
    {
        public Player SelectedPlayer { get; private set; }
        private ToolTip customToolTip = new ToolTip();
        private Font myFont = new Font("Arial", 15f, FontStyle.Bold);

        public CharacterSelectionForm()
        {
            InitializeComponent();

            Mage.SizeMode = PictureBoxSizeMode.Zoom;
            Warrior.SizeMode = PictureBoxSizeMode.Zoom;
            Archer.SizeMode = PictureBoxSizeMode.Zoom;

            Mage.Image = Properties.Resources.Dumbledore;
            Warrior.Image = Properties.Resources.Pikachu;
            Archer.Image = Properties.Resources.ArcherS;

            customToolTip.OwnerDraw = true;
            customToolTip.Popup += (s, e) =>
            {
                e.ToolTipSize = TextRenderer.MeasureText(customToolTip.GetToolTip(e.AssociatedControl), myFont);
            };
            customToolTip.Draw += (s, e) =>
            {
                e.DrawBackground();
                e.DrawBorder();
                e.Graphics.DrawString(e.ToolTipText, myFont, Brushes.Black, e.Bounds);
            };

            customToolTip.SetToolTip(btnMage, "Name: DAMBLDOR\nLevel: 1\nXP: 0 / 100\nHP: 30 / 30\nMP: 45 / 45\nGold: 50G\n\nATTRIBUTES\nSTR: 2 | AGI: 4\nINT: 9 | END: 3\n\nCOMBAT STATS\nAttack Power: 14\nDefense: 2\nCrit Chance: 2%\nDodge Chance: 10%\n\nEQUIPMENT\nWeapon: Elder Wand\nArmor: Mage Robe");

            customToolTip.SetToolTip(btnWarrior, "Name: PIKACHU\nLevel: 1\nXP: 0 / 100\nHP: 70 / 70\nMP: 10 / 10\nGold: 50G\n\nATTRIBUTES\nSTR: 8 | AGI: 3\nINT: 2 | END: 7\n\nCOMBAT STATS\nAttack Power: 21\nDefense: 7\nCrit Chance: 1.5%\nDodge Chance: 10%\n\nEQUIPMENT\nWeapon: Lightning Tail\nArmor: None");

            customToolTip.SetToolTip(btnArcher, "Name: ARCHER\nLevel: 1\nXP: 0 / 100\nHP: 40 / 40\nMP: 15 / 15\nGold: 50G\n\nATTRIBUTES\nSTR: 4 | AGI: 9\nINT: 3 | END: 4\n\nCOMBAT STATS\nAttack Power: 18\nDefense: 4\nCrit Chance: 4.5%\nDodge Chance: 10%\n\nEQUIPMENT\nWeapon: Enchanted Bow\nArmor: Leather Armor");


        }

        private void btnMage_Click(object sender, EventArgs e)
        {
            SelectedPlayer = new Player("Dumbledore", 1);
            SelectedPlayer.Strength = 2;
            SelectedPlayer.Agility = 4;
            SelectedPlayer.Intelligence = 9;
            SelectedPlayer.Endurance = 3;

            SelectedPlayer.Weapon = new Weapon("Elder Wand", 15, 0);
            SelectedPlayer.Armor = new Armor("Mage Robe", 10, 0);

            SelectedPlayer.RecalculateStats();
            SelectedPlayer.HP.Value = SelectedPlayer.HP.Max;
            SelectedPlayer.MP.Value = SelectedPlayer.MP.Max;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnWarrior_Click(object sender, EventArgs e)
        {
            SelectedPlayer = new Player("Pikachu", 1);
            SelectedPlayer.Strength = 8;
            SelectedPlayer.Agility = 3;
            SelectedPlayer.Intelligence = 2;
            SelectedPlayer.Endurance = 7;

            SelectedPlayer.Weapon = new Weapon("Lightning Tail", 10, 0);

            SelectedPlayer.RecalculateStats();
            SelectedPlayer.HP.Value = SelectedPlayer.HP.Max;
            SelectedPlayer.MP.Value = SelectedPlayer.MP.Max;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnArcher_Click(object sender, EventArgs e)
        {
            SelectedPlayer = new Player("Archer", 1);
            SelectedPlayer.Strength = 4;
            SelectedPlayer.Agility = 9;
            SelectedPlayer.Intelligence = 3;
            SelectedPlayer.Endurance = 4;

            SelectedPlayer.Weapon = new Weapon("Enchanted Bow", 10, 0);
            SelectedPlayer.Armor = new Armor("Leather Armor", 2, 0);

            SelectedPlayer.RecalculateStats();
            SelectedPlayer.HP.Value = SelectedPlayer.HP.Max;
            SelectedPlayer.MP.Value = SelectedPlayer.MP.Max;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
