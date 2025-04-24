using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Generic;
using _2D_Framework_Game.Interfaces;
using _2D_Framework_Game.Objects.Attack;

namespace _2D_Framework_Game.Strategies
{
    public class DefaultAttackStrategy : IAttackStrategy
    {
        public int ExecuteAttack(List<IAttackComponent> items)
        {
            int total = 0;
            foreach (var item in items)
            {
                total += item.GetHit();
            }
            return total;
        }
    }
}

