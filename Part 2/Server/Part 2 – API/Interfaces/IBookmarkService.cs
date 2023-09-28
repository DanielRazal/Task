using Part_2___API.Models;

namespace Part_2___API.Interfaces
{
    public interface IBookmarkService
    {
        List<Item> GetBookmarkedItems();
        void SetBookmarkItem(Item item);
        void RemoveBookmarkItem(int itemId);
    }
}