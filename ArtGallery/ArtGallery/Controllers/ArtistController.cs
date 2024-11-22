using ArtGallery.Core.Abstraction;
using ArtGallery.Infrastructure.Data.Entities;
using ArtGallery.Models.Artist;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtGallery.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }
        // GET: ArtistController
        public ActionResult Index()
        {
            var artists = _artistService.GetArtists()
                       .Select(a => new ArtistVM
                       {
                           Id = a.Id,
                           FirstName = a.FirstName,
                           LastName = a.LastName,
                           Biography = a.Biography,
                           YearBorn = a.YearBorn
                       }).ToList();

            return View(artists);
        }

        // GET: ArtistController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ArtistController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArtistController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ArtistVM artist)
        {
            if (ModelState.IsValid)
            {
                var success = _artistService.CreateArtist(artist.FirstName, artist.LastName, artist.Biography, artist.YearBorn);
                if (success>0)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", "Unable to create artist.");
            }

            return View(artist);
        }

        // GET: ArtistController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ArtistController/Edit/5
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

        // GET: ArtistController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ArtistController/Delete/5
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
