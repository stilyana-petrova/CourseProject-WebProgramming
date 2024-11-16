using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Infrastructure.Data.Entities
{
    public class Cart
    {
        public string Id { get; set; }
       
       // public string CartId { get; set; }

       // public int Quantity { get; set; }

      //  public System.DateTime DateCreated { get; set; }
        
        //[ForeignKey(nameof(Product))]
        //public int ProductId { get; set; }
        //public virtual Product Product { get; set; }

        [ForeignKey(nameof(Order))]

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

    }
}
