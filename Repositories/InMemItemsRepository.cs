using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(items);
        }
        public async Task<Item> GetItemAsync(Guid id)
        {
            return await Task.FromResult(items.Where(item => item.Id == id).SingleOrDefault());
        }

        public async Task CreateItemAsync(Item item)
        {
            items.Add(item);
            await Task.CompletedTask;

        }
        public async Task UpdateItemAsync(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
            await Task.CompletedTask;
        }
        public async Task DeleteItemAsync(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
           await Task.CompletedTask;
        }
    }
}