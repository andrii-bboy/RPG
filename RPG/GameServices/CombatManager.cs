using System;
using RPG.Entitites.Characters;
using RPG.Entitites.Characters.Enemies;

namespace RPG.GameServices
{
    public class CombatManager
    {
        private Player _player;
        private Enemy _enemy;
        private bool _isPlayerBlocking;
        private bool _isEnemyBlocking;
        private bool _isPlayerDodging;
        private readonly Random _random = new Random();

        public Player Player => _player;
        public Enemy Enemy => _enemy;

        public CombatManager(Player player, Enemy enemy)
        {
            _player = player;
            _enemy = enemy;
            _isPlayerBlocking = false;
            _isEnemyBlocking = false;
            _isPlayerDodging = false;
        }

        public string PlayerAttack()
        {
            if (_player.MP.Value < 2) return "Not enough MP!";
            _player.MP.decrease(2);

            int dmg = _player.CalculateAttackPower();
            bool isCrit = _random.NextDouble() * 100 <= _player.CriticalChance;
            string critText = isCrit ? "CRIT! " : "";
            if (isCrit) dmg *= 2;

            if (_isEnemyBlocking)
            {
                dmg /= 2;
                _isEnemyBlocking = false;
            }

            _enemy.HP.decrease(dmg);
            return $"{critText}You hit for {dmg} dmg. (Spent 2 MP)";
        }

        public string PlayerPowerStrike()
        {
            if (_player.MP.Value < 15) return "Not enough MP!";
            _player.MP.decrease(15);
            int dmg = (int)(_player.CalculateAttackPower() * 1.6);

            if (_isEnemyBlocking)
            {
                dmg /= 2;
                _isEnemyBlocking = false;
            }

            _enemy.HP.decrease(dmg);
            return $"Power Strike! Dealt {dmg} dmg.";
        }

        public string PlayerActivateBlock()
        {
            _isPlayerBlocking = true;
            return "You entered a defensive stance. Damage reduced by 50% on the next turn.";
        }

        public string PlayerHeal()
        {
            if (_player.MP.Value < 10) return "Not enough mana for Healing!";
            _player.MP.decrease(10);
            int healAmount = _player.Intelligence * 3;
            _player.HP.increase(healAmount);
            return $"Healing! You restored {healAmount} HP.";
        }

        public string PlayerDodge()
        {
            _isPlayerDodging = true;
            return "You focused on resting! Your dodge chance is significantly boosted for the next attack.";
        }
        public string ExecuteEnemyTurn()
        {
            if (_enemy.HP.Value <= 0) return string.Empty;

            int playerHealAmount = Math.Max(1, _player.Endurance / 3);
            int playerManaAmount = Math.Max(1, _player.Intelligence / 4);

            _enemy.HP.increase((int)(_enemy.getLevel() * 0.2));

            if (_isPlayerDodging)
            {
                _isPlayerDodging = false;

                if (_random.Next(1, 101) <= _player.DodgeChance)
                {
                    playerHealAmount = (int)(playerHealAmount * 1.5);
                    playerManaAmount = playerManaAmount * 2;

                    _player.HP.increase(playerHealAmount);
                    _player.MP.increase(playerManaAmount);

                    return $"Dodge Success! {_enemy.getName()} attacked, but you evaded completely! Critical Rest: (+{playerHealAmount} HP / +{playerManaAmount} MP)";
                }
                else
                {
                    _player.HP.increase(playerHealAmount);
                    _player.MP.increase(playerManaAmount);

                    int enemyAttackPower = _enemy.getAttack() + (_enemy.getLevel() * 2);
                    int rawDamage = Math.Max(2, enemyAttackPower - _player.CalculateDefense());
                    _player.HP.decrease(rawDamage);
                    return $"Dodge Failed! {_enemy.getName()} caught you off guard and dealt {rawDamage} damage. (+{playerHealAmount} HP / +{playerManaAmount} MP)";
                }
            }

            _player.HP.increase(playerHealAmount);
            _player.MP.increase(playerManaAmount);

            int baseEnemyAttack = _enemy.getAttack() + (_enemy.getLevel() * 2);
            int finalDamage = Math.Max(2, baseEnemyAttack - _player.CalculateDefense());

            if (_isPlayerBlocking)
            {
                finalDamage /= 2;
                _isPlayerBlocking = false;
            }

            _player.HP.decrease(finalDamage);
            return $"{_enemy.getName()} attacks and deals {finalDamage} damage. (+{playerHealAmount} HP / +{playerManaAmount} MP)";
        }
    }
}
