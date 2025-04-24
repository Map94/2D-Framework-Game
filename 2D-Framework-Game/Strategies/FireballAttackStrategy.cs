using System;
using _2D_Framework_Game.Interfaces;
using _2D_Framework_Game.Objects.Attack;

namespace _2D_Framework_Game.Strategies
{
    public class FireballAttackStrategy : IAttackStrategy
    {
        public int ExecuteAttack(List<IAttackComponent> components)
        {
            return 35; // Fireball attack deals 35 damage
        }
    }
}
