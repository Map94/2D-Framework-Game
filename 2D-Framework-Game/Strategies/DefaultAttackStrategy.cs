using System;
using System.Linq;
using System.Collections.Generic;
using _2D_Framework_Game.Interfaces;
using _2D_Framework_Game.Objects.Attack;

namespace _2D_Framework_Game.Strategies
{
    public class DefaultAttackStrategy : IAttackStrategy
    {
        public int ExecuteAttack(List<IAttackComponent> items)
        {
            // Using LINQ to sum the damage from all attack components
            return items.Sum(item => item.GetHit());  // Sum up the damage from all attack components
        }
    }
}
