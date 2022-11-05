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
        //Admin
        [HttpGet("[action]")]
        public async Task<List<CategoryAminDTO>> getAllCategoriesAdmin()
        {
            return await _category_Repository.GetCategoriesAdmin();
        }
        [HttpGet("[action]/{categoryId}")]
        public async Task<CategoryAminDTO> getCategoryByIdAdmin(int categoryId)
        {
            return await _category_Repository.GetCategoryByIdAdmin(categoryId);
        }
        [HttpPost]
        public bool addCategoriesAdmin(CategoryAminDTO categoryAdmin)
        {
            if (_category_Repository.AddCategoriesAdmin(categoryAdmin))
            {
                return true;
            }
            return false;
        }
        [HttpPut]
        public bool updateCategoryAdmin(CategoryAminDTO categoryAmin)
        {
            if (_category_Repository.UpdateCategoryAdmin(categoryAmin))
            {
                return true;
            }
            return false;
        }
    }
}
