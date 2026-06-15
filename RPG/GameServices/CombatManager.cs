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
        private readonly Random _random = new Random();

        public Player Player => _player;
        public Enemy Enemy => _enemy;

        public CombatManager(Player player, Enemy enemy)
        {
            _player = player;
            _enemy = enemy;
            _isPlayerBlocking = false;
            _isEnemyBlocking = false;
        }

        public string PlayerAttack()
        {
            if (_player.MP.Value < 2)
            {
                return "Not enough mana for a normal attack!";
            }

            _player.MP.decrease(2);

            int dmg = _player.CalculateAttackPower();
            bool isCrit = _random.NextDouble() * 100 <= _player.CriticalChance;
            string critText = "";

            if (isCrit)
            {
                dmg *= 2;
                critText = "CRITICAL HIT! ";
            }

            if (_isEnemyBlocking)
            {
                dmg /= 2;
                _isEnemyBlocking = false;
            }

            _enemy.HP.decrease(dmg);
            return $"{critText}You attacked {_enemy.getName()} for {dmg} damage. (Spent 2 MP)";
        }


        public string PlayerPowerStrike()
        {
            if (_player.MP.Value < 15)
            {
                return "Not enough mana for Power Strike!";
            }

            _player.MP.decrease(15);
            int dmg = (int)(_player.CalculateAttackPower() * 1.6);

            if (_isEnemyBlocking)
            {
                dmg /= 2;
                _isEnemyBlocking = false;
            }

            _enemy.HP.decrease(dmg);
            return $"Power Strike! You dealt {dmg} damage to {_enemy.getName()}.";
        }

        public string PlayerActivateBlock()
        {
            _isPlayerBlocking = true;
            return "You entered a defensive stance. Damage reduced by 50% on the next turn.";
        }

        public string PlayerHeal()
        {
            if (_player.MP.Value < 10)
            {
                return "Not enough mana for Healing!";
            }

            _player.MP.decrease(10);
            int healAmount = _player.Intelligence * 3;
            _player.HP.increase(healAmount);
            return $"Healing! You restored {healAmount} HP.";
        }

        public string ExecuteEnemyTurn()
        {
            if (_enemy.HP.Value <= 0) return string.Empty;

            int playerHealAmount = _player.getLevel() * 2;
            int playerManaAmount = _player.getLevel() * 2;

            _player.HP.increase(playerHealAmount);
            _player.MP.increase(playerManaAmount);

            _enemy.HP.increase((int)(_enemy.getLevel() * 0.2));

            if (_random.Next(1, 101) <= 25)
            {
                _isEnemyBlocking = true;
                return $"{_enemy.getName()} entered a defensive stance! (Regenerated {playerHealAmount} HP / {playerManaAmount} MP)";
            }

            int rawDamage = Math.Max(1, _enemy.getAttack() - _player.CalculateDefense());

            if (_isPlayerBlocking)
            {
                rawDamage /= 2;
                _isPlayerBlocking = false;
            }

            _player.HP.decrease(rawDamage);
            return $"{_enemy.getName()} attacks you and deals {rawDamage} damage. (You Regenerated {playerHealAmount} HP / {playerManaAmount} MP)";
        }

    }
}