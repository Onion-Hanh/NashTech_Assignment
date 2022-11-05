using API.Models;
using CommonModel.Product;
using CommonModel.Rating;
using Customers_Site.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Customers_Site.Services
{
    public class Rating_Service:IRating_Service
    {
        IHttpClientFactory _factory;
        List<RatingDTO> ratings;
        public Rating_Service(IHttpClientFactory factory)
        {
            _factory = factory;
        }
        public async Task<List<RatingDTO>> getRatingsByProductId(int productId)
        {
            ratings = new List<RatingDTO>();
            var httpClient = _factory.CreateClient();
            var reponseMessage = await httpClient.GetAsync("Rating/" + productId);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var data = await reponseMessage.Content.ReadAsStringAsync();
                ratings = JsonConvert.DeserializeObject<List<RatingDTO>>(data);
            }
            return ratings;
        }
        public async Task<List<RatingDTO>> addRating(RatingDTO rating)
        {
            ratings = new List<RatingDTO>();
            var httpClient = _factory.CreateClient();
            string data = JsonConvert.SerializeObject(rating);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            var reponseMessage = await httpClient.PostAsync("Rating",content);
            if (reponseMessage.IsSuccessStatusCode)
            {
                var data1 = await reponseMessage.Content.ReadAsStringAsync();
                ratings = JsonConvert.DeserializeObject<List<RatingDTO>>(data1);
            }
            return ratings;
        }
    }
}
