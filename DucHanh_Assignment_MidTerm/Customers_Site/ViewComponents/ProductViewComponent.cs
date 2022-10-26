using CommonModel.Product;
using Customers_Site.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customers_Site.ViewComponents
{
    public class ProductViewComponent : ViewComponent
    {
        public readonly IProduct_Service _product_Service;
        List<ProductDTO> listProduct;
        public ProductViewComponent(IProduct_Service product_Service)
        {
            _product_Service = product_Service;
        }
        public async Task<IViewComponentResult> InvokeAsync(string categoryId, string productName)
        {
            listProduct = new List<ProductDTO>();
            if (categoryId == null && productName == null)
            {
                listProduct = await _product_Service.getListProducts();
                return View<List<ProductDTO>>("Product", listProduct);
            }
            else if (categoryId != null)
            {
                listProduct = await _product_Service.getProductsByCategoryId(categoryId);
                return View<List<ProductDTO>>("Product", listProduct);
            }
            else
            {
                listProduct = await _product_Service.getProductsByName(productName);
                return View<List<ProductDTO>>("Product", listProduct);
            }
        }
    }
}
