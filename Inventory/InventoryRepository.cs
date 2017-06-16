using System;
using System.Collections.Generic;
using System.Linq;
using StoreFront.Inventory.Model;

namespace StoreFront.Inventory
{
    public class InventoryRepository
    {
        private readonly IList<Item> _items;

        private readonly IWorthCalculator _worthCalculator;

        public InventoryRepository()
        {
            // this should most likely be injected at startup from composition root, but this works for now.
            _items = new List<Item>()
            {
                new Item {Name = "Aluminum Shackles", ShelfLife = 10, Worth = 20},
                new Item {Name = "Gold", ShelfLife = 2, Worth = 0},
                new Item {Name = "Plutonium Pinball Parts", ShelfLife = 5, Worth = 7},
                new Item {Name = "Cadmium", ShelfLife = 0, Worth = 80},
                new Item {Name = "Helium", ShelfLife = 15, Worth = 20},
                new Item {Name = "Alchemy Iron", ShelfLife = 3, Worth = 6}
            };
        }

        public InventoryRepository(IList<Item> items, IWorthCalculator worthCalculator)
        {
            _items = items;
            _worthCalculator = worthCalculator;
        }

        public IList<Item> Items
        {
            get { return _items; }
        }

        public Item GetItem(string name)
        {
            var item = _items.FirstOrDefault(x => x.Name == name);
            
            if (item == null)
            {
                throw new InvalidOperationException();
            }
            
            return item;
        }

        public void UpdateWorth()
        {
            foreach (Item t in _items)
            {
                _worthCalculator.UpdateWorth(t);
            }
        }
    }

}
