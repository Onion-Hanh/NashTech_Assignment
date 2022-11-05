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
            CreateMap<Product, ProductDTO>().ForMember(dto => dto.CategoryName, src => src.MapFrom(category => category.Category.Name));
            CreateMap<Product, ProductAdminDTO>().ForMember(dto => dto.CategoryName, src => src.MapFrom(category => category.Category.Name));
        }
    }
}
