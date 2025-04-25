using System;
using _2D_Framework_Game.Objects.Creatures;
using _2D_Framework_Game.Strategies;

namespace _2D_Framework_Game.Objects.SubCreature
{
    public class Warrior : Creature
    {
        public Warrior(string name, int x, int y, int hitPoints,int inventoryCapacity)
            : base(name, hitPoints, x, y, inventoryCapacity)
        {
            AttackStrategy = new MeleeAttackStrategy();
        }
    }
}
