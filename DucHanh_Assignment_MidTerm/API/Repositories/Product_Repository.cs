using API.Data;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CommonModel.Product;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class Product_Repository : IProduct_Repository
    {
        public readonly DrugStoreDBContext _drugStoreDBContext;
        public IMapper _mapper;
        public Product_Repository(DrugStoreDBContext drugStoreDBContext, IMapper mapper)
        {
            _drugStoreDBContext = drugStoreDBContext;  
            _mapper = mapper;
        }

        public async Task<List<ProductDTO>> GetProducts()
        {
            return await _drugStoreDBContext.products.ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public async Task<List<ProductDTO>> GetProdctsByCategoryId(string categoryId)
        {          
            return await _drugStoreDBContext.products.ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).Where(c=>c.CategoryID== categoryId).ToListAsync();
        }
        public async Task<ProductDTO> GetProductDetail(string productId)
        {
            return await _drugStoreDBContext.products.ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).Where(c => c.Id == productId).FirstOrDefaultAsync();
        }
        public async Task<List<ProductDTO>> GetProductsByName(string productName)
        {
            return await _drugStoreDBContext.products.ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).Where(c => c.Name.Contains(productName)).ToListAsync();
        }
    }
}
