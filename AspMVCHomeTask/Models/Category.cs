namespace AspMVCHomeTask.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public decimal Price { get; set; }
		public int ProductCount { get; set; } 
		public ICollection<Product> Products { get; set; }
        public bool SoftDeleted { get; set; }
    }
}
