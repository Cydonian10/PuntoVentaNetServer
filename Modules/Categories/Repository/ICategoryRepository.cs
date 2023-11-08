using ApiStore.Data;

namespace ApiStore.Modules.Categories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> List();
        Task<bool> SaveOne(CreateCategoryDto dto);
        Task<bool> UpdateOne(UpdateCategoryDto dto, Guid id);
        Task<bool> RemoveOne(Guid id);
    }
}
