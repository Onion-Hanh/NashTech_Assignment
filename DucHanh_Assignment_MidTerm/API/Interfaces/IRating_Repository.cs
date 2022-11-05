using API.Models;
using CommonModel.Rating;

namespace API.Interfaces
{
    public interface IRating_Repository
    {
        Task<List<RatingDTO>> GetRatingByProductId(int productId);
        Task<List<RatingDTO>> AddRating(RatingDTO rating);
    }
}
