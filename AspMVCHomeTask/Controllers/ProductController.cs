using AspMVCHomeTask.Data;
using AspMVCHomeTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AspMVCHomeTask.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICategoryService _categoryService;

        // Объединение конструкторов в один
        public ProductController(AppDbContext context, ICategoryService categoryService)
        {
            _context = context;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        [HttpPost]
        public async Task<IActionResult> RestoreFromArchive(int? id)
        {
            if (id == null) return BadRequest();

            var category = await _categoryService.GetByIdAsync((int)id);

            if (category == null) return NotFound();

            category.SoftDeleted = false;
            await _categoryService.UpdateAsync(category);

            return Ok();
        }
    }
}
