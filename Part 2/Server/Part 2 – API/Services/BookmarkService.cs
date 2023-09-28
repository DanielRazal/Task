
using Newtonsoft.Json;
using Part_2___API.Interfaces;
using Part_2___API.Models;

namespace Part_2___API.Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BookmarkService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<Item> GetBookmarkedItems()
        {
            var itemJson = _httpContextAccessor.HttpContext!.Session.GetString("BookmarkedItems");

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
            _httpContextAccessor.HttpContext!.Session.SetString("BookmarkedItems", updatedItemsJson);
        }
    }

}