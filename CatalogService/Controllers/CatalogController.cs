using Business.Core.Catalog;
using Catalog.BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogController : ControllerBase
    {

        private readonly ILogger<CatalogController> _logger;
        private readonly IBusinessLayer<Category> _categoryManager;
        private readonly IBusinessLayer<Item> _itemManager;

        public CatalogController(ILogger<CatalogController> logger, IBusinessLayer<Category> categoryManager)
        {
            _logger = logger;
            _categoryManager = categoryManager;

        }



        [HttpGet("getcategories")]
        [ProducesResponseType(typeof(IEnumerable<Category>), 200)]
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

        [HttpPost("addcategory")]
        public IActionResult AddCategory([FromBody] Category category)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryManager.Add(category);
                if (result != null)
                    return Ok(result);
            }
            return BadRequest();

        }

        [HttpPut("updatecategory/{categoryid}")]
        public IActionResult UpdateCategory(int categoryId, Category category)
        {
            if (ModelState.IsValid)
            {
                var result = _categoryManager.Update(categoryId, category);
                if (result != null)
                    return Ok(result);
            }
            return BadRequest();

        }

        [HttpDelete("removecategory/{categoryid}")]
        public IActionResult RemoveCategory(int categoryId)
        {
            return Ok(_categoryManager.Delete(categoryId));
        }

    }
}