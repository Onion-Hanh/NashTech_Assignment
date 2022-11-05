using CommonModel.Product;
namespace API.Interfaces
{
    public interface IProduct_Repository
    {
        //Customer
        Task<List<ProductDTO>> GetProducts();
        Task<List<ProductDTO>> GetProdctsByCategoryId(int categoryId);
        Task<ProductDTO> GetProductDetail(int productId);
        Task<List<ProductDTO>> GetProductsByName(string productName);
        //Admin
        Task<List<ProductAdminDTO>> GetProductsAdmin();
        Task<List<ProductAdminDTO>> GetProductsByNameAdmin(string productName);
    }
}
