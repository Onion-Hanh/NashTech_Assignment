using CommonModel.Product;

namespace Customers_Site.Interfaces
{
    public interface IProduct_Service
    {
        Task<List<ProductDTO>> getListProducts();
        Task<List<ProductDTO>> getProductsByCategoryId(string categoryId);
        Task<ProductDTO> getProductById(string productId);
        Task<List<ProductDTO>> getProductsByName(string productName);
    }
}
