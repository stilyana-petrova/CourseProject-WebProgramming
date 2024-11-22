using ArtGallery.Models.Artist;
using ArtGallery.Models.Category;
using System.ComponentModel.DataAnnotations;

namespace ArtGallery.Models.Product
{
    public class ProductCreateVM
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [Display(Name = "Product Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Category")]

        public int CategoryId { get; set; }
        public virtual List<CategoryVM> Categories { get; set; }=new List<CategoryVM>();

        [Required]
        [Display(Name = "Picture")]

        public string Picture { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "Price must be positive in range 0-100.")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        [Required]
        [Range(1, 10000, ErrorMessage = "Price must be positive in range 1-10000.")]
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]

        public decimal Price { get; set; }


        [Display(Name = "Discount")]
        public decimal Discount { get; set; }

        public int ArtistId { get; set; }
        public virtual List<ArtistVM> Artists { get; set; } = new List<ArtistVM>();

    }
}
