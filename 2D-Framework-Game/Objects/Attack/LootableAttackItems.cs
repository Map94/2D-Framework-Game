using System.Collections.Generic;

namespace _2D_Framework_Game.Objects.Attack
{
    /// <summary>
    /// A boosted attack item that is also a world object and can be looted.
    /// </summary>
    public class LootableBoostedAttackItem : WorldObject, IAttackComponent
    {
        private readonly IAttackComponent _baseComponent;
        private readonly int _bonus;

        public LootableBoostedAttackItem(string name, IAttackComponent baseComponent, int bonus)
            : base(name, true, true)
        {
            _baseComponent = baseComponent;
            _bonus = bonus;
        }

        public int GetHit() => _baseComponent.GetHit() + _bonus;
        public string Description => _baseComponent.Description + " (Boosted)";
    }

    /// <summary>
    /// A composite attack item that is also a world object and can be looted.
    /// </summary>
    public class LootableCompositeAttackItem : WorldObject, IAttackComponent
    {
        private readonly List<IAttackComponent> _components = new();

        public LootableCompositeAttackItem(string name)
            : base(name, true, true)
        {
        }

        public void AddComponent(IAttackComponent component)
        {
            _components.Add(component);
        }

        public int GetHit()
        {
            int total = 0;
            foreach (var c in _components)
                total += c.GetHit();
            return total;
        }

        public string Description => "Composite of: " + string.Join(", ", _components.ConvertAll(c => c.Description));
    }
}
