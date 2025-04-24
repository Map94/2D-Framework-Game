using _2D_Framework_Game.Objects.Creatures;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace _2D_Framework_Game.Objects
{
    public class World
    {
        private readonly List<Creature> creatures = new();
        private readonly List<WorldObject> objects = new();

        public World(int width, int height)
        {
            // Initialization of the world (size, etc.)
        }

        public void AddCreature(Creature creature)
        {
            creatures.Add(creature);
            // Remove redundant logging here:
            // Trace.WriteLine($"Creature {creature.Name} added at position ({creature.X}, {creature.Y})");
            // Add the creature to the world, log only once with HP:
            Trace.WriteLine($"Creature {creature.Name} added at position ({creature.X}, {creature.Y}) with {creature.HitPoints} HP");
        }

        public void AddObject(WorldObject obj)
        {
            objects.Add(obj);
            Trace.WriteLine($"Object {obj.Name} added to world");
        }

        // Other methods like AddItem, etc.
    }
}
