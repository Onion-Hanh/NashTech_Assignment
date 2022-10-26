using API.Data;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CommonModel.Category;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class Category_Repository:ICategory_Repository
    {
        public readonly DrugStoreDBContext _drugStoreDBContext;
        public readonly IMapper _mapper;
        public Category_Repository(DrugStoreDBContext drugStoreDBContext, IMapper mapper)
        {
            _drugStoreDBContext = drugStoreDBContext;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetCategories()
        {
            return await _drugStoreDBContext.categories.ProjectTo<CategoryDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }

    }
}
