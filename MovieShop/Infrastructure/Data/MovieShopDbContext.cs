using ApplicationCore.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class MovieShopDbContext: DbContext
{
    public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
    {
        
    }
    public DbSet<Genres> Genres { get; set; }
    public DbSet<Casts> Casts { get; set; }
    public DbSet<Movies> Movies { get; set; }
    public DbSet<Users> Users { get; set; }
    public DbSet<Roles> Roles { get; set; }
    public DbSet<MovieGenres> MovieGenres { get; set; }
    public DbSet<MovieCasts> MovieCasts { get; set; }
    public DbSet<Trailers> Trailers { get; set; }
    public DbSet<Favorites> Favorites { get; set; }
    public DbSet<Reviews> Reviews { get; set; }
    public DbSet<Purchases> Purchases { get; set; }
    public DbSet<UserRoles> UserRoles { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Define the primary keys for the entities with Keyless attribute
        modelBuilder.Entity<Favorites>()
            .HasKey(f => new { f.MovieId, f.UserId });

        modelBuilder.Entity<MovieCasts>()
            .HasKey(mc => new { mc.MovieId, mc.CastId });

        modelBuilder.Entity<MovieGenres>()
            .HasKey(mg => new { mg.MovieId, mg.GenreId });

        modelBuilder.Entity<Purchases>()
            .HasKey(p => new { p.MovieId, p.UserId });

        modelBuilder.Entity<Reviews>()
            .HasKey(r => new { r.MovieId, r.UserId });

        modelBuilder.Entity<UserRoles>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

        // Configure the relationships

        // MovieCasts relationship
        modelBuilder.Entity<MovieCasts>()
            .HasOne(mc => mc.Movie)
            .WithMany(m => m.MovieCasts)
            .HasForeignKey(mc => mc.MovieId);

        modelBuilder.Entity<MovieCasts>()
            .HasOne(mc => mc.Cast)
            .WithMany(c => c.MovieCasts)
            .HasForeignKey(mc => mc.CastId);

        // MovieGenres relationship
        modelBuilder.Entity<MovieGenres>()
            .HasOne(mg => mg.Movie)
            .WithMany(m => m.MovieGenres)
            .HasForeignKey(mg => mg.MovieId);

        modelBuilder.Entity<MovieGenres>()
            .HasOne(mg => mg.Genre)
            .WithMany(g => g.MovieGenres)
            .HasForeignKey(mg => mg.GenreId);

        // Trailers relationship
        modelBuilder.Entity<Trailers>()
            .HasOne(t => t.Movie)
            .WithMany(m => m.Trailers)
            .HasForeignKey(t => t.MovieId);

        // Favorites relationship
        modelBuilder.Entity<Favorites>()
            .HasOne(f => f.Movie)
            .WithMany(m => m.Favorites)
            .HasForeignKey(f => f.MovieId);

        modelBuilder.Entity<Favorites>()
            .HasOne(f => f.User)
            .WithMany(u => u.Favorites)
            .HasForeignKey(f => f.UserId);

        // Reviews relationship
        modelBuilder.Entity<Reviews>()
            .HasOne(r => r.Movie)
            .WithMany(m => m.Reviews)
            .HasForeignKey(r => r.MovieId);

        modelBuilder.Entity<Reviews>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId);

        // Purchases relationship
        modelBuilder.Entity<Purchases>()
            .HasOne(p => p.Movie)
            .WithMany(m => m.Purchases)
            .HasForeignKey(p => p.MovieId);

        modelBuilder.Entity<Purchases>()
            .HasOne(p => p.User)
            .WithMany(u => u.Purchases)
            .HasForeignKey(p => p.UserId);

        // UserRoles relationship
        modelBuilder.Entity<UserRoles>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

        modelBuilder.Entity<UserRoles>()
            .HasOne(ur => ur.Role)
            .WithMany(r => r.UserRoles)
            .HasForeignKey(ur => ur.RoleId);

        // Configure column types for properties marked with Column attribute
        modelBuilder.Entity<Movies>()
            .Property(m => m.BackdropUrl).HasColumnType("nvarchar(2084)");
        modelBuilder.Entity<Movies>()
            .Property(m => m.CreatedBy).HasColumnType("nvarchar(MAX)");
        modelBuilder.Entity<Movies>()
            .Property(m => m.ImdbUrl).HasColumnType("nvarchar(2084)");
        modelBuilder.Entity<Movies>()
            .Property(m => m.OriginalLanguage).HasColumnType("nvarchar(64)");
        modelBuilder.Entity<Movies>()
            .Property(m => m.Overview).HasColumnType("nvarchar(MAX)");
        modelBuilder.Entity<Movies>()
            .Property(m => m.PosterUrl).HasColumnType("nvarchar(2084)");
        modelBuilder.Entity<Movies>()
            .Property(m => m.Tagline).HasColumnType("nvarchar(512)");
        modelBuilder.Entity<Movies>()
            .Property(m => m.Title).HasColumnType("nvarchar(256)");
        modelBuilder.Entity<Movies>()
            .Property(m => m.TmdbUrl).HasColumnType("nvarchar(2084)");
        modelBuilder.Entity<Movies>()
            .Property(m => m.UpdatedBy).HasColumnType("nvarchar(MAX)");

        modelBuilder.Entity<Casts>()
            .Property(c => c.Gender).HasColumnType("nvarchar(MAX)");
        modelBuilder.Entity<Casts>()
            .Property(c => c.Name).HasColumnType("nvarchar(128)");
        modelBuilder.Entity<Casts>()
            .Property(c => c.ProfilePath).HasColumnType("nvarchar(2084)");
        modelBuilder.Entity<Casts>()
            .Property(c => c.TmdbUrl).HasColumnType("nvarchar(MAX)");

        modelBuilder.Entity<Genres>()
            .Property(g => g.Name).HasColumnType("nvarchar(24)");

        modelBuilder.Entity<Trailers>()
            .Property(t => t.Name).HasColumnType("nvarchar(2084)");
        modelBuilder.Entity<Trailers>()
            .Property(t => t.TrailerUrl).HasColumnType("nvarchar(2084)");

        modelBuilder.Entity<Reviews>()
            .Property(r => r.Rating).HasColumnType("decimal(3,2)");
        modelBuilder.Entity<Reviews>()
            .Property(r => r.ReviewText).HasColumnType("nvarchar(MAX)");

        modelBuilder.Entity<Roles>()
            .Property(r => r.Name).HasColumnType("nvarchar(20)");

        modelBuilder.Entity<Users>()
            .Property(u => u.Email).HasColumnType("nvarchar(256)");
        modelBuilder.Entity<Users>()
            .Property(u => u.FirstName).HasColumnType("nvarchar(128)");
        modelBuilder.Entity<Users>()
            .Property(u => u.HashedPassword).HasColumnType("nvarchar(1024)");
        modelBuilder.Entity<Users>()
            .Property(u => u.Lastname).HasColumnType("nvarchar(128)");
        modelBuilder.Entity<Users>()
            .Property(u => u.PhoneNumber).HasColumnType("nvarchar(16)");
        modelBuilder.Entity<Users>()
            .Property(u => u.ProfilePictureUrl).HasColumnType("nvarchar(MAX)");
        modelBuilder.Entity<Users>()
            .Property(u => u.Salt).HasColumnType("nvarchar(1024)");

        // Note: Keyless entities are marked with [Keyless] attribute in the entity class itself
    }
}