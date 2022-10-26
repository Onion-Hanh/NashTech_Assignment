using CommonModel.Category;
using CommonModel.Product;
using Customers_Site.Interfaces;
using Customers_Site.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Customers_Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategory_Service _category_Service;
        private readonly IProduct_Service _product_Service;
        List<CategoryDTO> listCategory = new List<CategoryDTO>();
        List<ProductDTO> listProduct = new List<ProductDTO>();
        public HomeController(ICategory_Service category_Service, IProduct_Service product_Service)
        {
            _category_Service = category_Service;
            _product_Service = product_Service;
        }
        public async Task<IActionResult> Index(string categoryId)
        {
            ViewBag.categoryId = categoryId;
            return View();
        }
        public async Task<IActionResult> ProductDetail(string productId)
        {
            ViewBag.productId = productId;
            return View();
        }
        public async Task<IActionResult> SearchProduct(IFormCollection form)
        {
            listProduct.Clear();
            string productName = form["search"];
            listProduct = await _product_Service.getProductsByName(productName);
            ViewBag.productName = productName;
            if (listProduct.Count == 0)
            {
                ViewBag.search = "Không có sản phẩm theo mục tìm kiếm";
            }
            return View("Index", listProduct);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}