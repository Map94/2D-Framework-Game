using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2D_Framework_Game.Objects;
using _2D_Framework_Game.Objects.Attack;

namespace _2D_Framework_Game.Objects.Attack
{
    public class Fireball : WorldObject, IAttackComponent
    {
        public int HitPoints { get; set; }

        // Constructor to initialize fireball with its name and hit points
        public Fireball(string name, int hitPoints)
            : base(name, true, true)  // Assuming fireballs can be looted and removed
        {
            HitPoints = hitPoints;
        }

        // IAttackComponent implementation
        public int GetHit() => HitPoints;

        public string Description => Name;
    }
}
