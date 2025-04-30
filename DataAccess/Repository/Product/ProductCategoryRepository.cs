using DataAccess.Data;
using Domain.Entity.Product;
using Domain.Repository.Product;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Product
{
    internal class ProductCategoryRepository : IProductCategoryRepository
    {
        #region Properties

        private readonly ApplicationDbContext _dbContext;

        #endregion

        public async Task CreateProductCategory(ProductCategory entity)
        {
            await _dbContext.ProductCategories.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProductCategoryAsync(ProductCategory productCategory)
        {
            _dbContext.ProductCategories.Remove(productCategory);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteProductCategoryAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ProductCategory>> GetAllProductCategoriesAsync() =>
            await _dbContext.ProductCategories.ToListAsync();

        public async Task<ProductCategory> GetProductCategoryAsync(string name) =>
            await _dbContext.ProductCategories.FirstOrDefaultAsync(x => x.Name == name);

        public async Task<ProductCategory> GetProductCategoryByIdAsync(int id) =>
            await _dbContext.ProductCategories.FindAsync(id);

        public async Task<ProductCategory> UpdateProductCategoryAsync(ProductCategory entity)
        {
            _dbContext.ProductCategories.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
