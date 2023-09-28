using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Part_2___API.Interfaces;
using Part_2___API.Models;
using System.Text;

public class BookmarkService : IBookmarkService
{
    private readonly IDistributedCache _cache;

    public BookmarkService(IDistributedCache cache)
    {
        _cache = cache ?? throw new ArgumentNullException(nameof(cache));
    }

    public List<Item> GetBookmarkedItems()
    {
        var itemJson = _cache.GetString("BookmarkedItems");

        if (!string.IsNullOrEmpty(itemJson))
        {
            return JsonConvert.DeserializeObject<List<Item>>(itemJson)!;
        }
        else
        {
            return new List<Item>();
        }
    }

    public void SetBookmarkItem(Item item)
    {
        var bookmarkedItems = GetBookmarkedItems();
        bookmarkedItems.Add(item);

        string updatedItemsJson = JsonConvert.SerializeObject(bookmarkedItems);

        _cache.SetString("BookmarkedItems", updatedItemsJson, new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
        });
    }

    public void RemoveBookmarkItem(int itemId)
    {
        var bookmarkedItems = GetBookmarkedItems();
        var itemToRemove = bookmarkedItems.FirstOrDefault(item => item.Id == itemId);

        if (itemToRemove != null)
        {
            bookmarkedItems.Remove(itemToRemove);

            string updatedItemsJson = JsonConvert.SerializeObject(bookmarkedItems);

            _cache.SetString("BookmarkedItems", updatedItemsJson, new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
            });
        }
    }

}
