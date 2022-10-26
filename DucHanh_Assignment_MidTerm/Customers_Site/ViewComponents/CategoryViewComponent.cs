using CommonModel.Category;
using Customers_Site.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customers_Site.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private readonly ICategory_Service _category_Service;
        List<CategoryDTO> listCategory = new List<CategoryDTO>();
        public CategoryViewComponent(ICategory_Service category_Service)
        {
            _category_Service = category_Service;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            listCategory = await _category_Service.getListCategories();
            return View<List<CategoryDTO>>("Category", listCategory);
        }
    }
}
