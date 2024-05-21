using AspMVCHomeTask.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspMVCHomeTask.Controllers
{
    public class StoregoodsController : Controller
	{
		private readonly AppDbContext _context;

		public StoregoodsController(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			var products = await _context.Products.ToListAsync();
			return View(products);
		}

	}
}
