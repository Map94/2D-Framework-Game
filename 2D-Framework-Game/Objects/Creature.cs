// Creature.cs
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
            string msg = $"{Name} received {hit} damage, remaining HP: {HitPoints}";
            Trace.WriteLine(msg);
            Console.WriteLine(msg);
            NotifyObservers($"{Name} was hit and lost {hit} HP.");

            if (HitPoints <= 0)
            {
                string deathMsg = $"{Name} has died.";
                Trace.WriteLine(deathMsg);
                Console.WriteLine(deathMsg);
            }
        }

        public virtual void Loot(WorldObject obj)
        {
            if (Inventory.AddItem(obj))
            {
                string msg = $"{Name} looted {obj.Name}.";
                Trace.WriteLine(msg);
                Console.WriteLine(msg);
            }
            else
            {
                string msg = $"{Name} could not loot {obj.Name} because the inventory is full.";
                Trace.WriteLine(msg);
                Console.WriteLine(msg);
            }
        }

        public virtual void OnNotified(string message)
        {
            Trace.WriteLine($"{Name} received notification: {message}");
        }

        public void SetAttackStrategy(IAttackStrategy strategy)
        {
            AttackStrategy = strategy;
            string msg = $"{Name} changed attack strategy to {strategy.GetType().Name}";
            Trace.WriteLine(msg);
            Console.WriteLine(msg);
        }

        public int PerformAttack()
        {
            var attackComponents = new List<IAttackComponent>();

            foreach (var item in Inventory.GetItems())
            {
                if (item is IAttackComponent attackItem)
                {
                    attackComponents.Add(attackItem);
                }
            }

            int totalDamage = AttackStrategy.ExecuteAttack(attackComponents);
            string msg = $"{Name} performed an attack dealing {totalDamage} damage.";
            Trace.WriteLine(msg);
            Console.WriteLine(msg);
            return totalDamage;
        }
    }
}