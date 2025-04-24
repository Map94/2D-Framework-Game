using System;
using _2D_Framework_Game.Interfaces;
using _2D_Framework_Game.Objects.Attack;

namespace _2D_Framework_Game.Strategies
{
    public class FireballAttackStrategy : IAttackStrategy
    {
        public int ExecuteAttack(List<IAttackComponent> components)
        {
            // Fireball always deals 35 damage (can be modified to account for additional factors like spell level, etc.)
            return 35;
        }
    }
}
