using API.Models;
using CommonModel.Product;
using Customers_Site.Interfaces;
using Newtonsoft.Json;

namespace Customers_Site.Services
{
    public class Product_Service : IProduct_Service
    {
        IHttpClientFactory _factory;
        List<ProductDTO> products;
        public Product_Service(IHttpClientFactory factory)
        {
            _factory = factory;
        }
        public async Task<List<ProductDTO>> getListProducts()
        {
            products = new List<ProductDTO>();
            var httpClient = _factory.CreateClient();
            var reponseMessage = await httpClient.GetAsync("Product");
            if (reponseMessage.IsSuccessStatusCode)
            {
                var data = await reponseMessage.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject < List<ProductDTO>>(data);
            }
            return products;
        }
        public async Task<List<ProductDTO>> getProductsByCategoryId(string categoryId)
        {
            products = new List<ProductDTO>();
            var httpClient = _factory.CreateClient();
            var reponseMessage = await httpClient.GetAsync("Product/" + categoryId);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var data = await reponseMessage.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ProductDTO>>(data);
            }
            return products;
        }
        public async Task<ProductDTO> getProductById(string productId)
        {
            ProductDTO product = new ProductDTO();
            var httpClient = _factory.CreateClient();
            var reponseMessage = await httpClient.GetAsync("Product/getProductById/" + productId);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var data = await reponseMessage.Content.ReadAsStringAsync();
                product = JsonConvert.DeserializeObject<ProductDTO>(data);
            }
            return product;
        }
        public async Task<List<ProductDTO>> getProductsByName(string productName)
        {
            products = new List<ProductDTO>();
            var httpClient = _factory.CreateClient();
            var reponseMessage = await httpClient.GetAsync("Product/getProductsByName/" + productName);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var data = await reponseMessage.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<List<ProductDTO>>(data);
            }
            return products;
        }
    }
}
