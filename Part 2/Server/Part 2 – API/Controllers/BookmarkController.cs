using Microsoft.AspNetCore.Mvc;
using Part_2___API.Interfaces;
using Part_2___API.Models;

namespace Controllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookmarkController : ControllerBase
    {
        private readonly IBookmarkService _bookmarkService;

        public BookmarkController(IBookmarkService bookmarkService)
        {
            _bookmarkService = bookmarkService;
        }


        [HttpPost("SetItem")]
        public ActionResult SetBookmarkItem(Item item)
        {
            _bookmarkService.SetBookmarkItem(item);

            var response = new
            {
                Message = "The item has been bookmarked in the session.",
                StatusCode = 200
            };

            return Ok(response);
        }

        [HttpGet("GetItems")]
        public ActionResult GetBookmarkedItems()
        {
            var bookmarkedItems = _bookmarkService.GetBookmarkedItems();

            if (bookmarkedItems.Count > 0)
            {
                return Ok(bookmarkedItems);
            }
            else
            {
                return NotFound("No bookmarked items found in the session.");
            }
        }

        [HttpDelete("RemoveItem/{itemId}")]
        public ActionResult RemoveBookmarkItem(int itemId)
        {
            var bookmarkedItems = _bookmarkService.GetBookmarkedItems();
            var itemToRemove = bookmarkedItems.FirstOrDefault(item => item.Id == itemId);

            if (itemToRemove == null)
            {
                return NotFound("Item not found in the session.");
            }

            _bookmarkService.RemoveBookmarkItem(itemId);

            var response = new
            {
                Message = "The item has been removed from the session.",
                StatusCode = 200
            };

            return Ok(response);
        }
    }
}