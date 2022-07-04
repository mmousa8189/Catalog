using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;

namespace Catalog.Repositories
{

    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new()
        {
            new Item {Id = Guid.NewGuid(), Name = "Mohamed Mousa", Price =9,CreeatedDate =DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Zaria", Price =11,CreeatedDate =DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Mora", Price =25,CreeatedDate =DateTimeOffset.UtcNow},
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }
        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }
        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }
    }
}