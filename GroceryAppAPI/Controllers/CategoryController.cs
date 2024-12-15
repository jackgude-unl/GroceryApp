using Microsoft.AspNetCore.Mvc;
using Accessors.Classes;
using Accessors.Interfaces;
using System.Collections.Generic;
using System;

namespace GroceryAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryAccessor _categoryAccessor;

        public CategoriesController(ICategoryAccessor categoryAccessor)
        {
            _categoryAccessor = categoryAccessor;
        }

        [HttpGet]
        public IActionResult GetAllCategories()
        {
            try
            {
                IEnumerable<Category> categories = _categoryAccessor.GetAllCategories();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}
