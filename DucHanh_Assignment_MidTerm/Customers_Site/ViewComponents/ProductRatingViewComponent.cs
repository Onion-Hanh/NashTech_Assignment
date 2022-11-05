using API.Models;
using CommonModel.Rating;
using Customers_Site.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Customers_Site.ViewComponents
{
    public class ProductRatingViewComponent : ViewComponent
    {
        public readonly IRating_Service _rating_Service;
        List<RatingDTO> ratings;
        public ProductRatingViewComponent(IRating_Service rating_Service)
        {
            _rating_Service = rating_Service;
        }
        public async Task<IViewComponentResult> InvokeAsync(int productId,int? star, string? comment)
        {
            ratings = new List<RatingDTO>();
            if (star != null && comment != null)
            {
                RatingDTO rating = new RatingDTO();
                rating.CustomerId = "KH0001";
                rating.ProductId = productId;
                rating.Stars = (int)star;
                rating.Comment = comment;
                ratings = await _rating_Service.addRating(rating);                               
            }
            else
            {
                ratings = await _rating_Service.getRatingsByProductId(productId);
                //lấy tổng sao và tổng số người comment của sản phẩm 'productId'
                ViewBag.numberOfRating = ratings.Count();
                double numberOfStar = 0;
                foreach (var item in ratings)
                {
                    numberOfStar = numberOfStar + item.Stars;
                }
                ViewBag.numberOfStar = numberOfStar;
            }
            return View<List<RatingDTO>>("ProductRating", ratings);
        }
    }
}
