using System;
using _2D_Framework_Game.Objects;
using _2D_Framework_Game.Objects.Creatures;
using _2D_Framework_Game.Objects.Attack;
using _2D_Framework_Game.Objects.SubCreature;  // Ensure this line is here for Mage and Warrior
using _2D_Framework_Game.Objects.World;  // Add this line to fix the World class not found error
using _2D_Framework_Game.Utilities;
using System.Diagnostics;

namespace GameTestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Setup logging
            LoggingConfig.Configure();

            // Create a world instance (make sure the World class is correctly implemented)
            var world = new World(10, 10);  // World size 10x10

            // Create creatures
            Mage mage = new("Merlin", 80, 1, 1);  // Adjusted to match the Creature constructor
            Warrior warrior = new("Conan", 120, 2, 2);  // Adjusted to match the Creature constructor

            world.AddCreature(mage);
            world.AddCreature(warrior);

            // Create attack items
            BasicAttackItem fireball = new("Fireball", 25, 5);
            BoostedAttackItem boostedFireball = new(fireball, 10, "Boosted Fireball", true, true);
            BasicAttackItem sword = new("Sword", 20, 2);
            BasicAttackItem axe = new("Axe", 30, 1);

            // Composite weapon for warrior
            CompositeAttackItem comboWeapon = new("Combo Weapon", true, true);
            comboWeapon.AddComponent(sword);
            comboWeapon.AddComponent(axe);

            // Add to world
            world.AddObject(fireball);
            world.AddObject(sword);
            world.AddObject(axe);

            // Mage loots boosted fireball
            mage.Loot(boostedFireball);

            // Warrior loots composite weapon
            warrior.Loot(comboWeapon);

            // Combat simulation
            Trace.WriteLine("\n--- Combat Begins ---");

            int mageHit = mage.Hit();
            warrior.ReceiveHit(mageHit);

            int warriorHit = warrior.Hit();
            mage.ReceiveHit(warriorHit);

            Trace.WriteLine("--- Combat Ends ---\n");

            Console.WriteLine("Simulation completed. Check logs for trace output.");
        }
    }
}
