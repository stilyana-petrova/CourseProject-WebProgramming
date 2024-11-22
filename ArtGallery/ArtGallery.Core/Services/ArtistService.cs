using ArtGallery.Core.Abstraction;
using ArtGallery.Data;
using ArtGallery.Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Core.Services
{
    public class ArtistService : IArtistService
    {
        private readonly ApplicationDbContext _context;
        public ArtistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Artist> GetArtists()
        {
            List<Artist> artists = _context.Artists.ToList();
            return artists;
        }

        public Artist GetArtistById(int artistId)
        {
            return _context.Artists.Find(artistId);
        }

        public List<Product> GetProductsByArtist(int artistId)
        {
            return _context.Products
                   .Where(p => p.ProductArtists.Any(pa => pa.ArtistId == artistId))
                   .ToList();
        }
        public int CreateArtist(string firstName, string lastName, string biography, int yearBorn)
        {
            var artist = new Artist
            {
                FirstName = firstName,
                LastName = lastName,
                Biography = biography,
                YearBorn = yearBorn
            };

            _context.Artists.Add(artist);
            _context.SaveChanges();

            return artist.Id; 
        }
    }
}
