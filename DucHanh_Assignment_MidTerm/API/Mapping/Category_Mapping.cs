using CommonModel.Category;
using API.Models;
using AutoMapper;

namespace API.Mapping
{
    public class Category_Mapping:Profile
    {
        public Category_Mapping()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<Category, CategoryAminDTO>();
        }
    }
}
