using DataAccess.Data;
using Domain.Entity.Product;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<string> CreateAllProductImagesByIdAsync(ProductImage productImages)
        {
            throw new NotImplementedException();
        }

        public async Task<Domain.Entity.Product.Product> CreateProductAsync(Domain.Entity.Product.Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await  _dbContext.SaveChangesAsync();
            return product;
        }

        public void DeleteProduct(Domain.Entity.Product.Product product)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }

        public async Task<List<Domain.Entity.Product.Product>> GetAllPricesByIdAsync(List<int> productIds)
        {
            var results = new List<Domain.Entity.Product.Product>();

            foreach (var productId in productIds)
            {
                var result = await _dbContext.Products.Where(item => item.Id == productId).ToListAsync();
                results.AddRange(result);
            }
            return results;
        }

        public Task<Domain.Entity.Product.Product> GetProductById(int id)
        {
            return _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Domain.Entity.Product.Product>> GetProductsAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<IEnumerable<Domain.Entity.Product.Product>> SearchProductsAsync(string productName, string categoryName)
        {
            var query = _dbContext.Products.AsQueryable();

            if (!string.IsNullOrEmpty(productName))
            {
                query = query.Where(p => p.Name.Contains(productName));
            }
            else if (!string.IsNullOrEmpty(categoryName))
            {
                var category = await _dbContext.ProductCategories
                    .FirstOrDefaultAsync(c => c.Name.Contains(categoryName));

                if (category != null)
                {
                    query = query.Where(p => p.CategoryId == category.Id);
                }
            }

            return await query.ToListAsync(); 
        }


        public async Task<Domain.Entity.Product.Product> UpdateProductRepository(Domain.Entity.Product.Product product)
        {
            var existingProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct == null)
            {
                throw new Exception("Product not found.");
            }


            _dbContext.Entry(existingProduct).CurrentValues.SetValues(product);

            await _dbContext.SaveChangesAsync();
            return existingProduct;
        }
    }
}
