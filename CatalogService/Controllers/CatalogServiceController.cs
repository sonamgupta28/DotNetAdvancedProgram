using Business.Core.Catalog;
using Catalog.BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogServiceController : ControllerBase
    {
        
        private readonly ILogger<CatalogServiceController> _logger;
        private readonly IBusinessLayer<Category> _categoryManager;
        private readonly IBusinessLayer<Item> _itemManager;

        public CatalogServiceController(ILogger<CatalogServiceController> logger, IBusinessLayer<Category> categoryManager, IBusinessLayer<Item> itemManager)
        {
            _logger = logger;
            _categoryManager = categoryManager;
            _itemManager = itemManager;   
        }

       
        [HttpGet("GetItems")]
        public IActionResult GetItems()
        {
            IEnumerable<Item> items = _itemManager.GetAll();
            return Ok(items);
        }

        [HttpGet("GetCategories")]
        public IActionResult GetCatogries()
        {
            IEnumerable<Category> categories = _categoryManager.GetAll();
            return Ok(categories);
        }

        //[HttpGet("{id}", Name = "GetItem")]
        //public IActionResult GetItem(long id)
        //{
        //    Item item = _itemManager.Get(id);
        //    if (item == null)
        //    {
        //        return NotFound("The Item record couldn't be found.");
        //    }
        //    return Ok(item);
        //}
      
        [HttpPost("PostItems")]
        public IActionResult PostItems([FromBody] Item item)
        {
            if (item == null)
            {
                return BadRequest("Item is null.");
            }
            _itemManager.Add(item);
            return Ok(item.ItemId);
        }
    }
}