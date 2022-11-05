using CommonModel.Product;

namespace Customers_Site.Interfaces
{
    public interface IProduct_Service
    {
        Task<List<ProductDTO>> getListProducts();
        Task<List<ProductDTO>> getProductsByCategoryId(int categoryId);
        Task<ProductDTO> getProductById(int productId);
        Task<List<ProductDTO>> getProductsByName(string productName);
    }
}
