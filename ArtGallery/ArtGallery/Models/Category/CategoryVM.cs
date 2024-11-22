using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ArtGallery.Models.Category
{
    public class CategoryVM
    {
        public int Id { get; set; }
        [Display(Name = "Category")]
        public string Name { get; set; }
    }
}
