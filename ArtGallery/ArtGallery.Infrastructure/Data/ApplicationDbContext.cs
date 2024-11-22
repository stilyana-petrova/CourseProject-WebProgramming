using ArtGallery.Infrastructure.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ArtGallery.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<ProductArtist> ProductArtists { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder); // Important to apply default configurations

            // Ensure composite key for IdentityUserLogin
            modelBuilder.Entity<IdentityUserLogin<string>>()
                   .HasKey(login => new { login.LoginProvider, login.ProviderKey });
           
            // Много-към-много връзка между Product и Artist
            modelBuilder.Entity<ProductArtist>()
                .HasKey(pa => new { pa.ProductId, pa.ArtistId });

            modelBuilder.Entity<ProductArtist>()
                .HasOne(pa => pa.Product)
                .WithMany(p => p.ProductArtists)
                .HasForeignKey(pa => pa.ProductId);

            modelBuilder.Entity<ProductArtist>()
                .HasOne(pa => pa.Artist)
                .WithMany(a => a.ProductArtists)
                .HasForeignKey(pa => pa.ArtistId);

        }
    }
}