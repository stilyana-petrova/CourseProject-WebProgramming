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
        private readonly ApplicationDbContext _context;

        public CheckoutController(ICheckoutService checkoutService, ApplicationDbContext context)
        {
            _checkoutService = checkoutService;
            _context = context;
        }

        // GET: Checkout
        public IActionResult Index()
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var model = new CheckoutFormVM();

            if (!string.IsNullOrEmpty(currentUserId))
            {
                var user = _context.Users.SingleOrDefault(u => u.Id == currentUserId);
                if (user != null)
                {
                    model.FullName = $"{user.FirstName} {user.LastName}";
                    model.Address = user.Address;
                    model.Email = user.Email;
                }
            }

            return View(model);
            //string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //ApplicationUser user = null;

            //// If the user is logged in, pass their information to the view
            //if (userId != null)
            //{
            //    user = _checkoutService.GetUserDetails(userId);
            //}

            //// Create the view model for the checkout form
            //var model = new CheckoutFormVM
            //{
            //    FullName = user?.FirstName + " " + user?.LastName,
            //    Address = user?.Address,
            //    Email = user?.Email
            //};

            //return View(model);
        }
        // POST: Checkout
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index([FromForm] CheckoutFormVM model)
        {
            string currentUserId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (ModelState.IsValid)
            {
                // Save the checkout information
                bool success = await _checkoutService.SaveCheckout(currentUserId, model.FullName, model.Address, model.Email,
                    model.Address2, model.Country, model.City, model.ZipCode, model.PhoneNumber, model.PaymentMethod);

                if (success)
                {
                    return RedirectToAction("Success");
                }
                else
                {
                    ModelState.AddModelError("", "An error occurred while processing your checkout.");
                }
            }

            return View(model);
        }

       

        // GET: Checkout/Success
        public IActionResult Success()
        {
            return View();
        }

    }
}
