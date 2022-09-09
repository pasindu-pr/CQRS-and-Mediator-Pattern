using CQRS.Data.Contracts;
using CQRS.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CQRS.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {

        private readonly DBContext _context;

        public ProductRepository(DBContext dBContext)
        {
            _context = dBContext;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product; 
        }


        public async Task<bool> DeleteProduct(int productId)
        {
            
            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);
            
            if(product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            
            return false;
        }

        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> UpdateProduct(int productId, Product productToUpdate)
        {

            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productId);

           if(product == null)
            {
                throw new Exception();
            }

           _context.Products.Update(productToUpdate);
           int saved = await _context.SaveChangesAsync();

            if(saved > 0)
            {
                return productToUpdate;
            }

            throw new Exception();
        }
    }
}
