using System;
using System.Collections.Generic;
using _2D_Framework_Game.Objects.Attack;

namespace _2D_Framework_Game.Objects.Attack
{
    public class CompositeAttackItem : WorldObject, IAttackComponent
    {
        private readonly List<IAttackComponent> _components = new List<IAttackComponent>();

        public CompositeAttackItem(string name, bool lootable, bool removable) : base(name, lootable, removable) { }

        public void AddComponent(IAttackComponent component)
        {
            _components.Add(component);
        }

        public int GetHit()
        {
            int totalHit = 0;
            foreach (var component in _components)
            {
                totalHit += component.GetHit();
            }
            return totalHit;
        }

        public string Description
        {
            get
            {
                var description = "Composite Weapon: ";
                foreach (var component in _components)
                {
                    description += component.Description + ", ";
                }
                return description.TrimEnd(' ', ',');
            }
        }
    }
}
