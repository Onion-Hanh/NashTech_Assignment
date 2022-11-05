using CommonModel.Paging;
using CommonModel.Product;
using Customers_Site.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public async Task<IViewComponentResult> InvokeAsync(int? categoryId, string productName, int page) 
        {
            listProduct = new List<ProductDTO>();
            if (categoryId == null && productName == null)
            {
                listProduct = await _product_Service.getListProducts();
            }
            else if (categoryId != null)
            {                
                listProduct = await _product_Service.getProductsByCategoryId(int.Parse(categoryId.ToString()));
            }
            else
            {
                listProduct = await _product_Service.getProductsByName(productName);
                if (listProduct.Count == 0)
                {
                    ViewBag.search = "Không có sản phẩm theo mục tìm kiếm";
                }
            }
            return View<List<ProductDTO>>("Product", Paging(page, listProduct));
        }
        public List<ProductDTO> Paging(int page, List<ProductDTO> list)
        {
            const int pageSize = 9;
            if (page < 1)
            {
                page = 1;
            }
            int totalItems = list.Count();
            PagerDTO pager = new PagerDTO(totalItems, page, pageSize);
            int recSkip = (page - 1) * pageSize;
            var data = list.Skip(recSkip).Take(pager.PageSize).ToList();
            ViewBag.Pager = pager;
            return data;
        }
    }
}
