using AspMVCHomeTask.Models;
using AspMVCHomeTask.Areas;

namespace AspMVCHomeTask.ViewModels.Categories
{
    public class CategoryProductVM : BaseEntity
    {
        public string CategoryName { get; set; }
        public string CreateDate { get; set; }
        public decimal Price { get; set; }
        public int ProductCount { get; set; }
    }
}
