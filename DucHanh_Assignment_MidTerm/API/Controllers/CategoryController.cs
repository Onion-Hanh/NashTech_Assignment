using API.Interfaces;
using CommonModel.Category;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        public readonly ICategory_Repository _category_Repository;
        public CategoryController(ICategory_Repository category_Repository)
        {
            _category_Repository = category_Repository;
        }
        [HttpGet]
        public async Task<List<CategoryDTO>> getAllCategories()
        {
            return await _category_Repository.GetCategories();
        }
    }
}
