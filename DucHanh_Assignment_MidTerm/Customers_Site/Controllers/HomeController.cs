using API.Models;
using CommonModel.Category;
using CommonModel.Product;
using CommonModel.Rating;
using Customers_Site.Interfaces;
using Customers_Site.Models;
using Customers_Site.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Customers_Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRating_Service _rating_Service;
        List<CategoryDTO> listCategory = new List<CategoryDTO>();
        List<ProductDTO> listProduct = new List<ProductDTO>();
        readonly Paging _paging;
        public HomeController(IRating_Service rating_Service, IOptions<Paging> paging)
        {       
            _rating_Service = rating_Service;
            _paging = paging.Value;
        }
        public async Task<IActionResult> Index(int? categoryId, bool index,int? page) 
        {
            if (page == null)
            {
                page = 1;
            }
            if (index == true)
            {
                _paging.category_Id = null;
                _paging.product_Name = null;
            }
            if (categoryId != null)
            {
                index = false;
                _paging.category_Id = categoryId;
                _paging.product_Name = null;
            }         
            ViewBag.productName = _paging.product_Name;
            ViewBag.categoryId= _paging.category_Id;
            ViewBag.page = page;
            return View();
        }
        public async Task<IActionResult> ProductDetail(int productId)
        {
            ViewBag.productId = productId;
            _paging.product_Id = productId;
            return View();
        }
        public async Task<IActionResult> SearchProduct(IFormCollection form, bool index,int? page) 
        {
            if (page == null)
            {
                page = 1;
            }
            ViewBag.page = page;
            listProduct.Clear();
            string productName = form["search"];
            if (productName != null)
            {
                index = false;
                _paging.category_Id = null;
                _paging.product_Name = productName;
                ViewBag.productName = _paging.product_Name;
            }
            return View("Index", listProduct);
        }

        public async Task<IActionResult> ProductRating(IFormCollection form)
        {
            string comment = form["comment"];
            int star = int.Parse(form["star"]);
            List<RatingDTO> ratings = new List<RatingDTO>();
            if (comment != null)
            {
                RatingDTO rating = new RatingDTO();               
                rating.CustomerId = "KH0001";
                rating.ProductId = _paging.product_Id;
                rating.Stars = star;
                rating.Comment = comment;
                rating.Date = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                ratings = await _rating_Service.addRating(rating);
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}