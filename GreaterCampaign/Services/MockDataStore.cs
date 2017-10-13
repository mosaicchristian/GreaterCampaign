using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreaterCampaign
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = 1, Date = "Nov 25", Read = "Psalm 46:8", Pray="Ask God to teach you how to pray more faithfully and honestly. Practice being still and hearing from Him." },
                new Item { Id = 2, Date = "Nov 26", Read = "Psalm 118:1", Pray="This is an item description." },
                new Item { Id = 3, Date = "Nov 27", Read = "Matthew 1:1", Pray="This is an item description." },
                new Item { Id = 4, Date = "Nov 28", Read = "Mark 1:1", Pray="This is an item description." },
                new Item { Id = 5, Date = "Nov 29", Read = "Luke 1:1", Pray="This is an item description." },
                new Item { Id = 6, Date = "Nov 30", Read = "John 1:1", Pray="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            var _item = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var _item = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(int id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}
