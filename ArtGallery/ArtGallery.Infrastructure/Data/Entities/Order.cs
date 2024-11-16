using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Infrastructure.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        [ForeignKey(nameof(ApplicationUser))]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }


        public virtual IEnumerable<Cart> Cart { get; set; } = new List<Cart>();
        public virtual IEnumerable<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
    }
}
