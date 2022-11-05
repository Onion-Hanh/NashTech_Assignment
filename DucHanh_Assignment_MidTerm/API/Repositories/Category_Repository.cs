using API.Data;
using API.Interfaces;
using API.Models;
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
        //Customer
        public async Task<List<CategoryDTO>> GetCategories()
        {
            return await _drugStoreDBContext.categories.ProjectTo<CategoryDTO>(_mapper.ConfigurationProvider).Where(c => c.Status == true).ToListAsync();
        }
        //Admin
        public async Task<List<CategoryAminDTO>> GetCategoriesAdmin()
        {
            return await _drugStoreDBContext.categories.ProjectTo<CategoryAminDTO>(_mapper.ConfigurationProvider).OrderByDescending(c=>c.Id).ToListAsync();
        }
        public async Task<CategoryAminDTO> GetCategoryByIdAdmin(int categoryId)
        {
            return await _drugStoreDBContext.categories.ProjectTo<CategoryAminDTO>(_mapper.ConfigurationProvider).Where(c => c.Id == categoryId).FirstOrDefaultAsync();
        }
        public bool AddCategoriesAdmin(CategoryAminDTO categoryAdmin)
        {
            Category category = new Category();
            category.Id = categoryAdmin.Id;
            category.Name = categoryAdmin.Name;
            category.Description = categoryAdmin.Description;
            category.CreateDate = DateTime.Now + "";
            category.Status = true;
            try
            {
                _drugStoreDBContext.categories.Add(category);
                _drugStoreDBContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool UpdateCategoryAdmin(CategoryAminDTO categoryAdmin)
        {
            var category = _drugStoreDBContext.categories.Where(c => c.Id == categoryAdmin.Id).FirstOrDefault();
            if (category != null)
            {
                category.Name = categoryAdmin.Name;
                category.Description = categoryAdmin.Description;            
                category.UpdateDate = DateTime.Now + "";
                category.Status = categoryAdmin.Status;
                _drugStoreDBContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
