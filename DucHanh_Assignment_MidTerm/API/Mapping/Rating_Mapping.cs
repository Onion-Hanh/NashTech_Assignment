using API.Interfaces;
using API.Models;
using API.Repositories;
using AutoMapper;
using CommonModel.Rating;

namespace API.Mapping
{
    public class Rating_Mapping : Profile
    {
        public Rating_Mapping()
        {
            CreateMap<Rating, RatingDTO>().ForMember(dto=>dto.CustomerName, src=>src.MapFrom(rating=>rating.Customer.Name));
        }
    }
}
