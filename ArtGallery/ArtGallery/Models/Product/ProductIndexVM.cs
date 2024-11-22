using ArtGallery.Models.Artist;
using ArtGallery.Models.Category;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ArtGallery.Models.Product
{
    public class ProductIndexVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<string> ArtistNames { get; set; }
        public string Picture { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Discount { get; set; }

    }
}
