using CommonModel.Product;
using Customers_Site.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customers_Site.ViewComponents
{
    public class ProductDetailViewComponent : ViewComponent
    {
        public readonly IProduct_Service _product_Service;
        ProductDTO product;
        public ProductDetailViewComponent(IProduct_Service product_Service)
        {
            _product_Service = product_Service; 
        }
        public async Task<IViewComponentResult> InvokeAsync(string productId)
        {
            product = new ProductDTO();
            product = await _product_Service.getProductById(productId);
            return View("ProductDetail", product);
        }
    }
}
