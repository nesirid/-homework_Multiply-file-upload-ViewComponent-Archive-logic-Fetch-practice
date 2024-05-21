using AspMVCHomeTask.Data;
using AspMVCHomeTask.ViewModels.Categories;
using AspMVCHomeTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AspMVCHomeTask.Models;



namespace AspMVCHomeTask.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<IEnumerable<CategoryProductVM>> GetAllWithProductCountAsync()
        {
            IEnumerable<Category> categories = await _context.Categories.Include(m => m.Products)
                                                                        .ToListAsync();
            return categories.Select(m => new CategoryProductVM
            {
                CategoryName = m.Name,
                CreateDate = m.CreateDate.ToString("MM.dd.yyyy"),
                Price = m.Price,
                ProductCount = m.ProductCount
            });
        }
        public async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public async Task UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetArchivedCategoriesAsync()
        {
            return await _context.Categories.Where(c => c.SoftDeleted).ToListAsync();
        }

    }


 }

