using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string Description { get; set; }

        // Navigation property for Products
        public virtual ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
