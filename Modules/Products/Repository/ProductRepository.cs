using ApiStore.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiStore.Modules.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;
        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task<bool> Create(CreateProductDto product)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAll()
        {
            var products = await _context.Products!.ToListAsync();
            return products;
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Guid id, UpdateProductDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
