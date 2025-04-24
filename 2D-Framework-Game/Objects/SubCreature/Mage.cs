﻿using System;
using _2D_Framework_Game.Objects.Creatures;
using _2D_Framework_Game.Strategies;

namespace _2D_Framework_Game.Objects.SubCreature
{
    public class Mage : Creature
    {
        public Mage(string name, int hitPoints, int x, int y, int inventoryCapacity)
            : base(name, hitPoints, x, y, inventoryCapacity)
        {
            AttackStrategy = new FireballAttackStrategy();
        }
    }
}
