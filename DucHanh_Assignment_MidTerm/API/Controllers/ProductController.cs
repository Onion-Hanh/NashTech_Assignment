using API.Interfaces;
using CommonModel.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IProduct_Repository _product_Repository;
        //Customer
        public ProductController(IProduct_Repository product_Repository)
        {
            _product_Repository = product_Repository;
        }
        [HttpGet]
        public async Task<List<ProductDTO>> getAllProducts()
        {
            return await _product_Repository.GetProducts();
        }
        [HttpGet("{categoryId}")]
        public async Task<IActionResult> getAllProductsByCategoryId(int categoryId)
        {
            var products = await _product_Repository.GetProdctsByCategoryId(categoryId);
            if (products == null)
            {
                return BadRequest();
            }
            return Ok(products);
        }
        [HttpGet("[action]/{productId}")]
        public async Task<IActionResult> getProductById(int productId)
        {
            var product = await _product_Repository.GetProductDetail(productId);
            if (product == null)
            {
                return BadRequest();
            }
            return Ok(product);
        }
        [HttpGet("[action]/{productName}")]
        public async Task<IActionResult> getProductsByName(string productName)
        {
            var products = await _product_Repository.GetProductsByName(productName);
            if (products == null)
            {
                return BadRequest();
            }
            return Ok(products);
        }
        //Admin
        [HttpGet("[action]")]
        public async Task<List<ProductAdminDTO>> getAllProductsAdmin()
        {
            return await _product_Repository.GetProductsAdmin();
        }
        [HttpGet("[action]/{productName}")]
        public async Task<List<ProductAdminDTO>> GetProductsByNameAdmin(string productName)
        {
            return await _product_Repository.GetProductsByNameAdmin(productName);
        }
    }
}
