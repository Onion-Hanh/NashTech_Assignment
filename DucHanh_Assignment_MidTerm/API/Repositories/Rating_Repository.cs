using API.Data;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CommonModel.Rating;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using API.Models;

namespace API.Repositories
{
    public class Rating_Repository:IRating_Repository
    {
        DrugStoreDBContext _drugStoreDBContext;
        IMapper _mapper;
        public Rating_Repository(DrugStoreDBContext drugStoreDBContext, IMapper mapper) 
        {
            _drugStoreDBContext = drugStoreDBContext;
            _mapper = mapper;
        }
        public async Task<List<RatingDTO>> GetRatingByProductId(int productId)
        {
            return await _drugStoreDBContext.ratings.ProjectTo<RatingDTO>(_mapper.ConfigurationProvider).Where(c => c.ProductId == productId)
                .OrderByDescending(c => c.Id)
                .ToListAsync();
        }
        public async Task<List<RatingDTO>> AddRating(RatingDTO rating) 
        {
            Rating _rating = new Rating();
            _rating.Id = rating.Id;
            _rating.CustomerId = rating.CustomerId;
            _rating.ProductId = rating.ProductId;
            _rating.Stars = rating.Stars;
            _rating.Comment = rating.Comment;
            _rating.Date = rating.Date;
            _drugStoreDBContext.ratings.Add(_rating);
            _drugStoreDBContext.SaveChanges();
            return await _drugStoreDBContext.ratings.ProjectTo<RatingDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
