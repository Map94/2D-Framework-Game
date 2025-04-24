using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2D_Framework_Game.Objects.Attack;

namespace _2D_Framework_Game.Objects.Defence
{
    /// <summary>
    /// Represents an item that can be used for defense.
    /// </summary>
    public class DefenceItem : WorldObject
    {
        public int ReduceHitPoint { get; set; }

        public DefenceItem(string name, int reduceHitPoint)
            : base(name, true, true)
        {
            ReduceHitPoint = reduceHitPoint;
        }
    }
}
