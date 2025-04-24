using System;
using _2D_Framework_Game.Interfaces;
using _2D_Framework_Game.Objects.Attack;

namespace _2D_Framework_Game.Strategies
{
    public class MeleeAttackStrategy : IAttackStrategy
    {
        public int ExecuteAttack(List<IAttackComponent> components)
        {
            // Melee attack deals 20 damage (this can be dynamic if creature stats or items are factored in)
            return 20;
        }
    }
}
