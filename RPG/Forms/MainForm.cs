using RPG.Entitites.Characters;
using RPG.Entitites.Characters.Enemies;
using RPG.Forms;
using RPG.GameServices;
using RPG.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RPG
{
    public partial class MainForm : Form
    {
        private SaveLoadService _saveLoadService = new SaveLoadService();
        private Player _player;
        private List<GameEvent> _events;

        public MainForm(Player chosenPlayer)
        {
            InitializeComponent();
            _player = chosenPlayer;
            _events = GameEvent.GenerateEvents();
            _player.RecalculateStats();
            UpdateMainFormUI();
            txtMainLog.ScrollBars = ScrollBars.Vertical;

            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
                           $"XP: 0 / 100\n" +
                           $"HP: {_player.HP.Value} / {_player.HP.Max}\n" +
                           $"MP: {_player.MP.Value} / {_player.MP.Max}\n" +
                           $"Gold: {_player.Gold}G\n\n" +
                           $"ATTRIBUTES\n" +
                           $"STR: {_player.Strength} | AGI: {_player.Agility}\n" +
                           $"INT: {_player.Intelligence} | END: {_player.Endurance}\n\n" +
                           $"COMBAT STATS\n" +
                           $"Attack Power: {_player.CalculateAttackPower()}\n" +
                           $"Defense: {_player.CalculateDefense()}\n" +
                           $"Crit Chance: {_player.CriticalChance}%\n" +
                           $"Dodge Chance: {_player.DodgeChance}%\n\n" +
                           $"EQUIPMENT\n" +
                           $"Weapon: {(_player.Weapon != null ? _player.Weapon.getName() : "Fists")}\n" +
                           $"Armor: {(_player.Armor != null ? _player.Armor.getName() : "None")}";
        }




        private void btnSave_Click(object sender, EventArgs e)
        {
            _saveLoadService.save(_player);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Player loadedPlayer = _saveLoadService.loadViaDialog();
            if (loadedPlayer != null)
            {
                _player.setLevel(loadedPlayer.getLevel());
                _player.Gold = loadedPlayer.Gold;
                _player.Strength = loadedPlayer.Strength;
                _player.Agility = loadedPlayer.Agility;
                _player.Intelligence = loadedPlayer.Intelligence;
                _player.Endurance = loadedPlayer.Endurance;
                _player.Weapon = loadedPlayer.Weapon;
                _player.Armor = loadedPlayer.Armor;
                _player.DodgeChance = loadedPlayer.DodgeChance;

                _player.RecalculateStats();

                _player.HP.Value = _player.HP.Max;
                _player.MP.Value = _player.MP.Max;

                UpdateMainFormUI();
                MessageBox.Show("Game loaded successfully!", "Loaded");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _saveLoadService.deleteViaDialog();
        }
    }
}
