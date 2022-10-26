using CommonModel.Product;
namespace API.Interfaces
{
    public interface IProduct_Repository
    {
        Task<List<ProductDTO>> GetProducts();
        Task<List<ProductDTO>> GetProdctsByCategoryId(string categoryId);
        Task<ProductDTO> GetProductDetail(string productId);
        Task<List<ProductDTO>> GetProductsByName(string productName);
    }
}
