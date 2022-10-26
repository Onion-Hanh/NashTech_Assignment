using CommonModel.Category;
namespace API.Interfaces
{
    public interface ICategory_Repository
    {
        Task<List<CategoryDTO>> GetCategories();
    }
}
