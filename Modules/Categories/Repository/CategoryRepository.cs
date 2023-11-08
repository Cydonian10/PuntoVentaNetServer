
using ApiStore.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiStore.Modules.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationContext _context;
        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        async public Task<List<Category>> List()
        {
            List<Category> categories = await _context.Categories!.ToListAsync();
            return categories;
        }

        async public Task<bool> RemoveOne(Guid id)
        {
            var category = await _context.Categories!.FirstOrDefaultAsync(e => e.Id == id);

            if (category == null) return false;

            _context.Categories!.Remove(category);
            await _context!.SaveChangesAsync();
            return true;

        }

        async public Task<bool> SaveOne(CreateCategoryDto dto)
        {

            Category category = new()
            {
                Id = Guid.NewGuid(),
                Name = dto.Name,
                Description = dto.Description,
            };

            await _context.Categories!.AddAsync(category);
            await _context.SaveChangesAsync();

            return true;

        }

        async public Task<bool> UpdateOne(UpdateCategoryDto dto, Guid id)
        {
            var category = await _context.Categories!.FirstOrDefaultAsync(e => e.Id == id);

            if (category == null) return false;

            category.Name = dto.Name ?? category.Name;
            category.Description = dto.Description ?? category.Description;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
