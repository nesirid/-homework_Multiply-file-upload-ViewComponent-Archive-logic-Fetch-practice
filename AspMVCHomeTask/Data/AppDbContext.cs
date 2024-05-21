using AspMVCHomeTask.Models;
using Microsoft.EntityFrameworkCore;
using AspMVCHomeTask.Areas.Admin.Controllers;
using AspMVCHomeTask.ViewModels.Categories;

namespace AspMVCHomeTask.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
