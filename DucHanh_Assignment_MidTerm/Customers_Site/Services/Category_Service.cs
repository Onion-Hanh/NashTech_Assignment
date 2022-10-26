using CommonModel.Category;
using Customers_Site.Interfaces;
using Newtonsoft.Json;
using System.Data.Common;

namespace Customers_Site.Services
{
    public class Category_Service : ICategory_Service
    {
        IHttpClientFactory _factory;
        List<CategoryDTO> categories;
        public Category_Service(IHttpClientFactory factory)
        {
            _factory = factory;
        }
        public async Task<List<CategoryDTO>> getListCategories()
        {
            categories = new List<CategoryDTO>();
            var httpClient = _factory.CreateClient();
            var responseMessage = await httpClient.GetAsync("Category");
            if (responseMessage.IsSuccessStatusCode)
            {
                var data = await responseMessage.Content.ReadAsStringAsync();
                categories = JsonConvert.DeserializeObject<List<CategoryDTO>>(data);
            }
            return categories;
        }
    }
}
