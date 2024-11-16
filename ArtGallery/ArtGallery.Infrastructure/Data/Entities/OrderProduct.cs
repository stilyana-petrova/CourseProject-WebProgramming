using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Infrastructure.Data.Entities
{
    public class OrderProduct
    {
        public int Id { get; set; }
        [ForeignKey(nameof(Order))]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "The price must be positive number.")]
        public decimal Price { get; set; }
        [Required]
        public decimal Discount { get; set; }
        public decimal TotalPrice 
        {
            get { return Quantity * Price - Quantity * Price * Discount / 100; }
        }

    }
}
