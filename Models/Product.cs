using System.ComponentModel.DataAnnotations;

namespace eCommerce.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than zero")]
        public decimal Price { get; set; }


        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
        public int Quantity { get; set; }
        [Display]
        public string ImagePath { get; set; }

        // Navigation property for Category
        [Required]
        public int CategoryId { get; set; }
       
        public virtual Category Category { get; set; }


    }
}
