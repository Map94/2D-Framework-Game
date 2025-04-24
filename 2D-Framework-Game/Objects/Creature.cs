using System;
using System.Collections.Generic;
using _2D_Framework_Game.Interfaces;
using System.Diagnostics;
using _2D_Framework_Game.Objects.Attack;
using _2D_Framework_Game.Objects.Inventory;
using _2D_Framework_Game.Strategies;

namespace _2D_Framework_Game.Objects.Creatures
{
    public abstract class Creature : IObserver
    {
        public string Name { get; set; }
        public int HitPoints { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public ItemInventory Inventory { get; set; }

        protected IAttackStrategy AttackStrategy = new DefaultAttackStrategy();
        private readonly List<IObserver> observers = new();

        protected Creature(string name, int hitPoints, int x, int y, int inventoryCapacity)
        {
            Name = name;
            HitPoints = hitPoints;
            X = x;
            Y = y;
            Inventory = new ItemInventory(inventoryCapacity);

        }


        public void RegisterObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers(string message)
        {
            foreach (var obs in observers)
            {
                obs.OnNotified(message);
            }
        }

        public virtual int Hit()
        {
            return AttackStrategy.ExecuteAttack(new List<IAttackComponent>());
        }

        public virtual void ReceiveHit(int hit)
        {
            HitPoints -= hit;
            Trace.WriteLine($"{Name} received {hit} damage, remaining HP: {HitPoints}");
            NotifyObservers($"{Name} was hit and lost {hit} HP.");

            if (HitPoints <= 0)
            {
                Trace.WriteLine($"{Name} has died.");
            }
        }

        public virtual void Loot(WorldObject obj)
        {
            if (Inventory.AddItem(obj))
            {
                Trace.WriteLine($"{Name} looted {obj.Name}");
            }
            else
            {
                Trace.WriteLine($"{Name} could not loot {obj.Name} because the inventory is full.");
            }
        }

        public virtual void OnNotified(string message)
        {
            Trace.WriteLine($"{Name} received notification: {message}");
        }
    }
}
