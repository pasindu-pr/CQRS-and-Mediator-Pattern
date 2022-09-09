using CQRS.Data.Entities; 

namespace CQRS.Data.Contracts
{
    public interface IProductRepository
    {
        public Task<List<Product>> GetProducts();

        public Task<Product> GetProductById(int id);

        public Task<Product> CreateProduct(Product product);

        public Task<Product> UpdateProduct(int productId, Product productToUpdate);

        public Task<bool> DeleteProduct(int productId);
    }
}
