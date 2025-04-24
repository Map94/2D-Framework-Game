using System;
using System.Collections.Generic;
using System.Linq;
using _2D_Framework_Game.Objects.Creatures;
using _2D_Framework_Game.Objects;

namespace _2D_Framework_Game.Objects.World
{
    public class World
    {
        public List<Creature> Creatures { get; set; }
        public List<WorldObject> Objects { get; set; } // Add support for WorldObjects (like weapons, shields)

        public World()
        {
            Creatures = new List<Creature>();
            Objects = new List<WorldObject>(); // Initialize the list of WorldObjects
        }

        // Add creatures to the world
        public void AddCreature(Creature creature)
        {
            if (creature != null)
            {
                Creatures.Add(creature);
            }
            else
            {
                Console.WriteLine("Error: Cannot add null creature.");
            }
        }

        // Add objects to the world (e.g., weapons, shields)
        public void AddObject(WorldObject obj)
        {
            if (obj != null)
            {
                Objects.Add(obj);
            }
            else
            {
                Console.WriteLine("Error: Cannot add null object.");
            }
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

        // Show all objects in the world
        public void ShowAllObjects()
        {
            Console.WriteLine("Objects in the World:");
            foreach (var obj in Objects)
            {
                Console.WriteLine($"{obj.Name} - {obj.Description}");
            }
        }
    }
}
