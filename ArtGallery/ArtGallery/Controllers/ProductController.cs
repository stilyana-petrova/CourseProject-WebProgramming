using ArtGallery.Core.Abstraction;
using ArtGallery.Infrastructure.Data.Entities;
using ArtGallery.Models.Artist;
using ArtGallery.Models.Category;
using ArtGallery.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IArtistService _artistService;

        public ProductController(IProductService productService, ICategoryService categoryService, IArtistService artistService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _artistService = artistService;
        }

        // GET: ProductController
        public ActionResult Index(string searchStringCategoryName, string searchStringArtistName, string searchStringProductName)
        {
            List<ProductIndexVM> products = _productService.GetProducts(searchStringCategoryName, searchStringArtistName, searchStringProductName)
                .Select(product => new ProductIndexVM
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    CategoryId=product.CategoryId,
                    CategoryName=product.Category.Name,
                    ArtistNames = product.ProductArtists.Select(pa => $"{pa.Artist.FirstName} {pa.Artist.LastName}").ToList(), 
                    Picture=product.Picture,
                    Quantity=product.Quantity,
                    Price=product.Price,
                    Discount=product.Discount

                }).ToList();
            return View(products);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var product = new ProductCreateVM();
            product.Categories = _categoryService.GetCategories()
                .Select(x => new CategoryVM()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToList();

            product.Artists = _artistService.GetArtists()
        .Select(a => new ArtistVM()
        {
            Id = a.Id,
            FirstName = a.FirstName,
            LastName = a.LastName
        }).ToList();

            return View(product);
        }


        //not working- will fix it

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ProductCreateVM product)
        {
            if (ModelState.IsValid)
            {
                var createdId = _productService.Create(product.Name, product.Description, product.CategoryId, product.Picture, product.Quantity, product.Price, product.Discount);

                if (createdId) 
                {
                    var createdProduct = _productService.GetProducts()
                                   .FirstOrDefault(p => p.Name == product.Name &&
                                                        p.Description == product.Description &&
                                                        p.CategoryId == product.CategoryId &&
                                                        p.Price == product.Price);
                    if (createdProduct != null)
                    {
                        var success = _productService.AddArtistToProduct(createdProduct.Id, product.ArtistId);

                        if (!success)
                        {
                            ModelState.AddModelError("", "Failed to associate the artist with the product.");
                            return View(product);
                        }

                        return RedirectToAction(nameof(Index));
                    }
                }
            }

            product.Categories = _categoryService.GetCategories()
                .Select(x => new CategoryVM
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList();

            product.Artists = _artistService.GetArtists()
                .Select(a => new ArtistVM
                {
                    Id = a.Id,
                    FirstName = a.FirstName,
                    LastName = a.LastName
                }).ToList();

            return View(product);


        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
