using ApiStore.Data;

namespace ApiStore.Modules.Products
{
    public interface IProductRepository
    {
        Task<bool> Create(CreateProductDto product);
        Task<Product> GetById(int id);
        Task<List<Product>> GetAll();
        Task<bool> Update(Guid id, UpdateProductDto dto);
        Task<bool> Remove(Guid id);
    }
}
