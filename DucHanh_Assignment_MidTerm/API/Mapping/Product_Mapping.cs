using API.Interfaces;
using API.Repositories;
using AutoMapper;
using API.Models;
using CommonModel.Product;

namespace API.Mapping
{
    public class Product_Mapping : Profile
    {
        public Product_Mapping()
        {
            CreateMap<Product, ProductDTO>();
        }
    }
}
