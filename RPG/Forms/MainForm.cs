using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using RPG.Entitites.Characters;
using RPG.Entitites.Characters.Enemies;
using RPG.GameServices;
using RPG.Utils;
using RPG.Items;
using RPG.Forms;

namespace RPG
{
    public partial class MainForm : Form
    {
        private Player _player;
        private List<GameEvent> _events;
        private const string SaveFileName = "savegame.dat";

        public MainForm()
        {
            InitializeComponent();
            _player = new Player("Hero", 1);
            _events = GameEvent.GenerateEvents();
            UpdateMainFormUI();
        }



        private void btnRoll_Click(object sender, EventArgs e)
        {
            int roll = CustomRandomizer.generateNumber(0, 99);

            if (roll < 15)
            {
                txtMainLog.AppendText("The journey continues quietly. Nothing happened." + Environment.NewLine);
            }
            else if (roll < 55)
            {
                GameEvent ev = _events[CustomRandomizer.generateNumber(0, _events.Count - 1)];
                ev.ApplyEffect(_player);
                txtMainLog.AppendText("Event: " + ev.Description + Environment.NewLine);
            }
            else if (roll < 85)
            {
                txtMainLog.AppendText("Danger ahead! A hostile creature appears..." + Environment.NewLine);

                Enemy enemy = Enemy.Generate(_player.getLevel());
                CombatForm combatForm = new CombatForm(_player, enemy);
                combatForm.ShowDialog();
            }
            else
            {
                txtMainLog.AppendText("You encountered a traveling equipment merchant!" + Environment.NewLine);

                ShopForm shopForm = new ShopForm(_player);
                shopForm.ShowDialog();
            }

            _player.RecalculateStats();
            UpdateMainFormUI();
        }

        private void UpdateMainFormUI()
        {
            lblInfo.Text = $"Name: {_player.getName()}\n" +
                           $"Level: {_player.getLevel()}\n" +
                           $"XP: {_player.Experience} / {_player.LevelCup}\n" +
                           $"HP: {_player.HP.Value} / {_player.Endurance * 10}\n" +
                           $"MP: {_player.MP.Value} / {_player.Intelligence * 5}\n" +
                           $"Gold: {_player.Gold}G\n\n" +
                           $"ATTRIBUTES\n" +
                           $"STR: {_player.Strength} | AGI: {_player.Agility}\n" +
                           $"INT: {_player.Intelligence} | END: {_player.Endurance}\n\n" +
                           $"COMBAT STATS\n" +
                           $"Attack Power: {_player.CalculateAttackPower()}\n" +
                           $"Defense: {_player.CalculateDefense()}\n" +
                           $"Crit Chance: {_player.CriticalChance}%\n\n" +
                           $"EQUIPMENT\n" +
                           $"Weapon: {(_player.Weapon != null ? _player.Weapon.Name : "Fists")}\n" +
                           $"Armor: {(_player.Armor != null ? _player.Armor.Name : "None")}";
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(SaveFileName))
                {
                    writer.WriteLine(_player.getLevel());
                    writer.WriteLine(_player.Gold);
                    writer.WriteLine(_player.Strength);
                    writer.WriteLine(_player.Agility);
                    writer.WriteLine(_player.Intelligence);
                    writer.WriteLine(_player.Endurance);

                    if (_player.Weapon != null)
                    {
                        writer.WriteLine(_player.Weapon.getName());
                        writer.WriteLine(_player.Weapon.getPrice());
                        writer.WriteLine(_player.Weapon.getDamage());
                    }
                    else
                    {
                        writer.WriteLine("None");
                    }

                    if (_player.Armor != null)
                    {
                        writer.WriteLine(_player.Armor.getName());
                        writer.WriteLine(_player.Armor.getPrice());
                        writer.WriteLine(_player.Armor.getDefense());
                    }
                    else
                    {
                        writer.WriteLine("None");
                    }
                }

                MessageBox.Show("Game progress successfully saved!", "Save Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving game: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadGameProgress()
        {
            try
            {
                if (!File.Exists(SaveFileName)) return;

                using (StreamReader reader = new StreamReader(SaveFileName))
                {
                    int lvl = int.Parse(reader.ReadLine());
                    _player.setLevel(lvl);
                    _player.Gold = int.Parse(reader.ReadLine());
                    _player.Strength = int.Parse(reader.ReadLine());
                    _player.Agility = int.Parse(reader.ReadLine());
                    _player.Intelligence = int.Parse(reader.ReadLine());
                    _player.Endurance = int.Parse(reader.ReadLine());

                    string weaponName = reader.ReadLine();
                    if (weaponName != "None")
                    {
                        int price = int.Parse(reader.ReadLine());
                        int dmg = int.Parse(reader.ReadLine());
                        _player.Weapon = new Items.Weapon(weaponName, price, dmg);
                    }

                    string armorName = reader.ReadLine();
                    if (armorName != "None")
                    {
                        int price = int.Parse(reader.ReadLine());
                        int def = int.Parse(reader.ReadLine());
                        _player.Armor = new Items.Armor(armorName, price, def);
                    }
                }

                _player.RecalculateStats();
            }
            catch
            {
                File.Delete(SaveFileName);
            }
        }
    }
}
