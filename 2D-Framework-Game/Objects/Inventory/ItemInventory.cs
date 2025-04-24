using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using _2D_Framework_Game.Objects;
using System.Diagnostics;

namespace _2D_Framework_Game.Objects.Inventory
{
    public class ItemInventory
    {
        private List<WorldObject> _items;
        public int Capacity { get; private set; }

        public ItemInventory(int capacity)
        {
            Capacity = capacity;
            _items = new List<WorldObject>();
        }

        // Add an item to the inventory if there is space
        public bool AddItem(WorldObject item)
        {
            if (_items.Count < Capacity)
            {
                _items.Add(item);
                return true;
            }
            else
            {
                Trace.WriteLine("Inventory is full! Cannot add item.");
                return false;
            }
        }

        // Get the list of items in the inventory
        public List<WorldObject> GetItems()
        {
            return _items;
        }

        // Remove an item from the inventory
        public bool RemoveItem(WorldObject item)
        {
            return _items.Remove(item);
        }

        // Check if an item exists in the inventory
        public bool ContainsItem(WorldObject item)
        {
            return _items.Contains(item);
        }
    }
}
