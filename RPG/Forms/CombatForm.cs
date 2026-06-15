using System;
using System.Windows.Forms;
using RPG.Entitites.Characters;
using RPG.Entitites.Characters.Enemies;
using RPG.GameServices;

namespace RPG.Forms
{

    public partial class CombatForm : Form
    {
        private readonly Player _player;
        private readonly Enemy _enemy;
        private readonly CombatManager _combatManager;

        public CombatForm(Player player, Enemy enemy)
        {
            InitializeComponent();
            _player = player;
            _enemy = enemy;
            _combatManager = new CombatManager(_player, _enemy);

            lblEnemyTitle.Text = $"{_enemy.getName()} [Level: {_enemy.getLevel()}]";
            UpdateCombatUI();
        }

        private void UpdateCombatUI()
        {
            lblPlayerHP.Text = $"Your HP: {_player.HP.Value}";
            lblPlayerMP.Text = $"Your MP: {_player.MP.Value}";
            lblEnemyHP.Text = $"Enemy HP: {_enemy.HP.Value}";
        }

        private void GameTurnStep(string playerActionText)
        {
            if (playerActionText.StartsWith("Not enough"))
            {
                txtCombatLog.Text = playerActionText;
                return;
            }

            
            txtCombatLog.Text = playerActionText + Environment.NewLine;
            UpdateCombatUI();

            if (CheckBattleOver()) return;

            
            string enemyActionText = _combatManager.ExecuteEnemyTurn();

            
            txtCombatLog.Text += enemyActionText;
            UpdateCombatUI();

            CheckBattleOver();
        }

        private bool CheckBattleOver()
        {
            if (_enemy.HP.decrease(0) == false)
            {
                MessageBox.Show($"Victory!\nGold found: {_enemy.getRewardGold()}G\nXP gained: {_enemy.getRewardXp()}", "Combat Ended");
                _player.Gold += _enemy.getRewardGold();
                _player.addExperience(_enemy.getRewardXp());
                this.Close();
                return true;
            }

            if (_player.HP.decrease(0) == false)
            {
                MessageBox.Show("You fell in battle... Game Over.", "Defeat", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return true;
            }

            return false;
        }
        private void btnHit_Click(object sender, EventArgs e) => GameTurnStep(_combatManager.PlayerAttack());
        private void btnStrongHit_Click(object sender, EventArgs e) => GameTurnStep(_combatManager.PlayerPowerStrike());
        private void btnBlock_Click(object sender, EventArgs e) => GameTurnStep(_combatManager.PlayerActivateBlock());
        private void btnHeal_Click(object sender, EventArgs e) => GameTurnStep(_combatManager.PlayerHeal());
    }
}
