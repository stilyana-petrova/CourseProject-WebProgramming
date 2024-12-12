using ArtGallery.Core.Abstraction;
using ArtGallery.Data;
using ArtGallery.Infrastructure.Data.Entities;
using ArtGallery.Models.Checkout;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ArtGallery.Controllers
{
    [Authorize]
    public class CheckoutController : Controller
    {
        private readonly ICheckoutService _checkoutService;

        public CheckoutController(ICheckoutService checkoutService)
        {
            _checkoutService = checkoutService;
        }

        // GET: Checkout
        public IActionResult Index()
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = new CheckoutFormVM();

            if (!string.IsNullOrEmpty(currentUserId))
            {
                var user = _checkoutService.GetUserDetails(currentUserId);
                if (user != null)
                {
                    model.FullName = $"{user.FirstName} {user.LastName}";
                    model.Address = user.Address;
                    model.Email = user.Email;
                }
            }

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CheckoutFormVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(currentUserId))
            {
                ModelState.AddModelError("", "User is not authenticated.");
                return View(model);
            }

            bool isSaved = _checkoutService.SaveCheckout(
                currentUserId,
                model.FullName,
                model.Address,
                model.Email,
                model.Address2,
                model.Country,
                model.City,
                model.ZipCode,
                model.PhoneNumber,
                model.PaymentMethod
            );

            if (isSaved)
            {
                return RedirectToAction("OrderSuccess", "ShoppingCart");
            }

            ModelState.AddModelError("", "Failed to process the checkout.");
            return View(model);
        }



        // GET: Checkout/Success
        public IActionResult Success()
        {
            return View();
        }

    }
}
