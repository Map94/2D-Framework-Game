using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2D_Framework_Game.Objects.Attack
{
    /// <summary>
    /// Basic attack item.
    /// </summary>
    public class BasicAttackItem : WorldObject, IAttackComponent
    {
        public int Hit { get; set; }
        public int Range { get; set; }
        public string Description => Name;

        public BasicAttackItem(string name, int hit, int range)
            : base(name, true, true)
        {
            Hit = hit;
            Range = range;
        }

        public int GetHit() => Hit;
    }
}

