using API.Interfaces;
using CommonModel.Rating;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        public readonly IRating_Repository _rating_Repostory;
        public RatingController(IRating_Repository rating_Repostory)
        {
            _rating_Repostory = rating_Repostory;
        }

        [HttpGet("{productId}")]
        public async Task<List<RatingDTO>> getRatingsByProductId(int productId)
        {
            return await _rating_Repostory.GetRatingByProductId(productId);
        }
        [HttpPost]
        public async Task<List<RatingDTO>> AddRating(RatingDTO rating)
        {
            return await _rating_Repostory.AddRating(rating);
        }
    }
}
