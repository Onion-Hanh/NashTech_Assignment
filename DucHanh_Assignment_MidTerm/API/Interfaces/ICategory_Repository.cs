using CommonModel.Category;
namespace API.Interfaces
{
    public interface ICategory_Repository
    {
        //Customer
        Task<List<CategoryDTO>> GetCategories();     
        //Admin
        Task<List<CategoryAminDTO>> GetCategoriesAdmin();
        Task<CategoryAminDTO> GetCategoryByIdAdmin(int categoryId);
        bool AddCategoriesAdmin(CategoryAminDTO categoryAmin);
        bool UpdateCategoryAdmin(CategoryAminDTO categoryAmin);
    }
}
