using System;

namespace _2D_Framework_Game.Objects.Attack
{
    public class BoostedAttackItem : WorldObject, IAttackComponent
    {
        private readonly IAttackComponent _baseComponent;
        private readonly int _bonus;

        public BoostedAttackItem(IAttackComponent baseComponent, int bonus, string name, bool lootable, bool removable)
            : base(name, lootable, removable)
        {
            _baseComponent = baseComponent;
            _bonus = bonus;
        }

        public int GetHit() => _baseComponent.GetHit() + _bonus;
        public string Description => _baseComponent.Description + " (Boosted)";
    }
}
