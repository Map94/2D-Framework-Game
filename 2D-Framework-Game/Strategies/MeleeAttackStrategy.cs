using System;
using _2D_Framework_Game.Interfaces;
using _2D_Framework_Game.Objects.Attack;

namespace _2D_Framework_Game.Strategies
{
    public class MeleeAttackStrategy : IAttackStrategy
    {
        public int ExecuteAttack(List<IAttackComponent> components)
        {
            return 20; // Melee attack deals 20 damage
        }
    }
}
