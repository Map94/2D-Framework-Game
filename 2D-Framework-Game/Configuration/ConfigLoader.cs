using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text.Json;

namespace _2D_Framework_Game.Configuration
{
    public static class ConfigLoader
    {
        public static GameConfig Load(string path)
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<GameConfig>(json);
        }
    }
}
