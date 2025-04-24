using System;
using System.Collections.Generic;
using System.Linq;
using _2D_Framework_Game.Objects.Creatures;

namespace _2D_Framework_Game.Objects.World
{
    public class World
    {
        public List<Creature> Creatures { get; set; }

        public World()
        {
            Creatures = new List<Creature>();
        }

        // Add creatures to the world
        public void AddCreature(Creature creature)
        {
            Creatures.Add(creature);
        }

        // Show weak creatures (HP < 50)
        public void ShowWeakCreatures()
        {
            var weakCreatures = Creatures.Where(c => c.HitPoints < 50).ToList();
            Console.WriteLine("Weak Creatures (HP < 50):");
            foreach (var creature in weakCreatures)
            {
                Console.WriteLine($"{creature.Name} has {creature.HitPoints} HP.");
            }
        }

        // Show strong creatures (HP > 100)
        public void ShowStrongCreatures()
        {
            var strongCreatures = Creatures.Where(c => c.HitPoints > 100).ToList();
            Console.WriteLine("Strong Creatures (HP > 100):");
            foreach (var creature in strongCreatures)
            {
                Console.WriteLine($"{creature.Name} has {creature.HitPoints} HP.");
            }
        }
    }
}
