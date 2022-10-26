using CommonModel.Category;

namespace Customers_Site.Interfaces
{
    public interface ICategory_Service
    {
        Task<List<CategoryDTO>> getListCategories();
    }
}
