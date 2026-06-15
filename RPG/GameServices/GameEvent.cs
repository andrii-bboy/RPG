using System;
using System.Collections.Generic;
using RPG.Entitites.Characters;

namespace RPG.GameServices
{
    public class GameEvent
    {
        public string Description { get; set; }
        public Action<Player> ApplyEffect { get; set; }

        public GameEvent(string description, Action<Player> applyEffect)
        {
            Description = description;
            ApplyEffect = applyEffect;
        }

        public static List<GameEvent> GenerateEvents()
        {
            return new List<GameEvent>
            {
                new GameEvent("You found a pouch with coins! (+25 Gold)", p => p.addGold(25)),
                new GameEvent("You rested near a crystal spring. (+20 HP, +10 MP)", p => { p.HP.increase(20); p.MP.increase(10); }),
                new GameEvent("An old alchemist gave you a strange potion. (+2 Intelligence)", p => p.Intelligence += 2),
                new GameEvent("You trained with a local master. (+1 Strength)", p => p.Strength += 1),
                new GameEvent("You found a lucky horseshoe! (+1 Agility)", p => p.Agility += 1),
                new GameEvent("A beautiful day for a walk, you feel energized. (+1 Endurance)", p => p.Endurance += 1),
                new GameEvent("You helped a peasant and he rewarded you. (+15 Gold)", p => p.addGold(15)),
                new GameEvent("You were attacked by a swarm of wild bees! (-15 HP)", p => p.HP.decrease(15)),
                new GameEvent("You tripped over a rock and spilled some coins... (-40 Gold)", p => p.spendGold(Math.Max(0, p.Gold - 40))),
                new GameEvent("You caught a cold in the dark forest. (-2 Endurance)", p => p.Endurance = Math.Max(1, p.Endurance - 2))
            };
        }
    }
}
