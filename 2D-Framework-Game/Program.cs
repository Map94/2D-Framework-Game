using System;
using System.IO;
using System.Text.Json;
using _2D_Framework_Game.Configuration;
using _2D_Framework_Game.Objects;
using _2D_Framework_Game.Objects.Creatures;
using _2D_Framework_Game.Objects.Attack;
using _2D_Framework_Game.Objects.SubCreature;

namespace _2D_Framework_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Read configuration
            string json = File.ReadAllText("gameconfig.json");
            GameConfig config = JsonSerializer.Deserialize<GameConfig>(json);

            Console.WriteLine($"Game level: {config.Level}");
            Console.WriteLine($"World size: {config.MaxX} x {config.MaxY}");

            // Create the world using config values
            World world = new World(config.MaxX, config.MaxY);

            // Add sample creature
            Mage mage = new Mage("Gandalf", 100, 1, 1, 2);
            world.AddCreature(mage);

            // ... More setup / example testing here ...
        }
    }
}
