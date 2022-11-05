using CommonModel.Rating;

namespace Customers_Site.Interfaces
{
    public interface IRating_Service
    {
        Task<List<RatingDTO>> getRatingsByProductId(int productId);
        Task<List<RatingDTO>> addRating(RatingDTO rating);
    }
}
