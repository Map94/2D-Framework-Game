using System;
using System.IO;
using System.Collections.Generic;
using _2D_Framework_Game.Objects.SubCreature;
using _2D_Framework_Game.Objects.Attack;
using _2D_Framework_Game.Objects.Defence;
using _2D_Framework_Game.Objects;
using _2D_Framework_Game.Strategies;
using System.Text;

namespace GameTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup logging to file and console
            string logPath = "gamelog.txt";
            if (File.Exists(logPath)) File.Delete(logPath);

            var writer = new StreamWriter(logPath) { AutoFlush = true };
            var console = Console.Out;
            var multiWriter = new MultiTextWriter(console, writer);
            Console.SetOut(multiWriter);

            Console.WriteLine("--- Game Start ---\n");

            // Create world
            var world = new World(10, 10);

            // Create subcreatures
            Mage mage = new Mage("Merlin", 1, 1, 80, 2);
            Warrior warrior = new Warrior("Conan", 2, 2, 120, 2);

            Console.WriteLine($"{mage.Name} spawned at ({mage.X}, {mage.Y}) with {mage.HitPoints} HP");
            Console.WriteLine($"{warrior.Name} spawned at ({warrior.X}, {warrior.Y}) with {warrior.HitPoints} HP\n");

            world.AddCreature(mage);
            world.AddCreature(warrior);

            // Create weapons
            BasicAttackItem fireball = new BasicAttackItem("Fireball", 35, 2);
            BasicAttackItem sword = new BasicAttackItem("Sword", 20, 1);
            BasicAttackItem axe = new BasicAttackItem("Axe", 25, 1);

            // Add items to world
            world.AddObject(fireball);
            world.AddObject(sword);
            world.AddObject(axe);

            // Looting phase
            mage.Loot(fireball);
            warrior.Loot(axe);

            Console.WriteLine();

            // Set fireball strategy for mage
            mage.SetAttackStrategy(new FireballAttackStrategy());

            // Show weak and strong creatures
            Console.WriteLine("Weak Creatures:");
            foreach (var c in world.GetCreaturesByStrength(false, 100))
                Console.WriteLine($"- {c.Name} ({c.HitPoints} HP)");

            Console.WriteLine("\nStrong Creatures:");
            foreach (var c in world.GetCreaturesByStrength(true, 100))
                Console.WriteLine($"- {c.Name} ({c.HitPoints} HP)");

            Console.WriteLine("\n--- Combat Begins ---");

            Random rand = new Random();
            int round = 1;

            while (mage.HitPoints > 0 && warrior.HitPoints > 0)
            {
                Console.WriteLine($"\n--- Round {round} ---");

                bool mageFirst = rand.Next(2) == 0;

                if (mageFirst)
                {
                    int mageDamage = mage.PerformAttack();
                    warrior.ReceiveHit(mageDamage);
                    if (warrior.HitPoints <= 0) break;

                    int warriorDamage = warrior.PerformAttack();
                    mage.ReceiveHit(warriorDamage);
                }
                else
                {
                    int warriorDamage = warrior.PerformAttack();
                    mage.ReceiveHit(warriorDamage);
                    if (mage.HitPoints <= 0) break;

                    int mageDamage = mage.PerformAttack();
                    warrior.ReceiveHit(mageDamage);
                }

                round++;
            }

            Console.WriteLine("\n--- Combat Ends ---");
            if (mage.HitPoints > 0)
                Console.WriteLine($"{mage.Name} wins with {mage.HitPoints} HP remaining!");
            else
                Console.WriteLine($"{warrior.Name} wins with {warrior.HitPoints} HP remaining!");

            // Clean up
            writer.Close();
        }
    }

    public class MultiTextWriter : TextWriter
    {
        private readonly TextWriter _console;
        private readonly TextWriter _file;

        public MultiTextWriter(TextWriter console, TextWriter file)
        {
            _console = console;
            _file = file;
        }

        public override Encoding Encoding => Encoding.UTF8;

        public override void WriteLine(string value)
        {
            _console.WriteLine(value);
            _file.WriteLine(value);
        }

        public override void Write(string value)
        {
            _console.Write(value);
            _file.Write(value);
        }
    }
}