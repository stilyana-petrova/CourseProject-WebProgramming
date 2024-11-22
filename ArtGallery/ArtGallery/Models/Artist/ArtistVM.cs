using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ArtGallery.Models.Artist
{
    public class ArtistVM
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Range(1000, 2024)]
        [Display(Name = "Birth Year")]

        public int YearBorn { get; set; }

        [Display(Name = "Biography")]
        public string Biography { get; set; }
    }
}
