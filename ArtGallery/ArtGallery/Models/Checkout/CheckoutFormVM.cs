using ArtGallery.Infrastructure.Data.Entities;
using System.ComponentModel.DataAnnotations;

namespace ArtGallery.Models.Checkout
{
    public class CheckoutFormVM
    {
     
        public string UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }
        [Required]
        public string Email { get; set; }

        public string Address2 { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string ZipCode { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string PaymentMethod { get; set; }

        public DateTime CheckoutDate { get; set; }


        //public List<ShoppingCartItem> CartItems { get; set; } = new List<ShoppingCartItem>();
        // public decimal TotalAmount { get; set; }
    }
}
