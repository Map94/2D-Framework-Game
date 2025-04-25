using _2D_Framework_Game.Objects.Creatures;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace _2D_Framework_Game.Objects
{
    public class World
    {
        private List<Creature> _creatures = new();
        private List<WorldObject> _objects = new();
        private int _width;
        private int _height;

        public World(int width, int height)
        {
            _width = width;
            _height = height;
        }

        public void AddCreature(Creature creature)
        {
            _creatures.Add(creature);
            string msg = $"{creature.Name} spawned at ({creature.X}, {creature.Y}) with {creature.HitPoints} HP.";
            Trace.WriteLine(msg);
            Console.WriteLine(msg);
        }

        public void AddObject(WorldObject obj)
        {
            _objects.Add(obj);
        }

        public void ShowWeakCreatures()
        {
            Console.WriteLine("\nWeak Creatures:");
            foreach (var creature in GetCreaturesByStrength(false, 100))
                Console.WriteLine($"- {creature.Name} ({creature.HitPoints} HP)");
        }

        public void ShowStrongCreatures()
        {
            Console.WriteLine("\nStrong Creatures:");
            foreach (var creature in GetCreaturesByStrength(true, 100))
                Console.WriteLine($"- {creature.Name} ({creature.HitPoints} HP)");
        }

        public IEnumerable<Creature> GetCreaturesByStrength(bool isStrong, int strengthThreshold)
        {
            return isStrong
                ? _creatures.Where(c => c.HitPoints > strengthThreshold)
                : _creatures.Where(c => c.HitPoints <= strengthThreshold);
        }
    }
}
