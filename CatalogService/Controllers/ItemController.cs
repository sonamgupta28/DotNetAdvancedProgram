using Business.Core.Catalog;
using Catalog.BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {

        private readonly ILogger<ItemController> _logger;
        private readonly IBusinessLayer<Item> _itemManager;

        public ItemController(ILogger<ItemController> logger,
            IBusinessLayer<Item> itemManager)
        {
            _logger = logger;
            _itemManager = itemManager;
        }


        [HttpGet("getitems")]
        [ProducesResponseType(typeof(IEnumerable<Item>), 200)]
        public IActionResult GetItems()
        {
            IEnumerable<Item> items = _itemManager.GetAll();
            return Ok(items);
        }

        [HttpGet("getitems/{categoryId}/{pageNumber}")]
        public IActionResult Get(int categoryId, int pageNumber)
        {
            return Ok(_itemManager.Get(categoryId, pageNumber));
        }


        [HttpPost("additem")]
        public IActionResult AddItem([FromBody] Item item)
        {
            if (ModelState.IsValid)
            {
                var result = _itemManager.Add(item);
                if (result != null)
                    return Ok(result);
            }
            return BadRequest();

        }

        [HttpPut("updateitem/{itemid}")]
        public IActionResult UpdateCategory(int itemid, Item item)
        {
            if (ModelState.IsValid)
            {
                var result = _itemManager.Update(itemid, item);
                if (result != null)
                    return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("removeitem/{itemid}")]
        public IActionResult RemoveCategory(int itemid)
        {
            return Ok(_itemManager.Delete(itemid));
        }

    }
}
