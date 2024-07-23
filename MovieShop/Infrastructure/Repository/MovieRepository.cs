using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using ApplicationCore.Model.Response;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository;

public class MovieRepository: BaseRepository<Movies>, IMovieRepository
{
    private readonly MovieShopDbContext _movieShopDbContext;

    public MovieRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
        _movieShopDbContext = movieShopDbContext;
    }
    //GetMoviesByGenreAsync
    public async Task<IEnumerable<Movies>> GetByGenreAsync(string genre)
    {
        return _movieShopDbContext.Movies
            .Where(m => m.MovieGenres.Any(g => g.Genre.Name == genre)).ToList();
    }
    //GetMovieDetailsAsync
    public async Task<Movies> GetByIdAsync(int id)
    {
        return _movieShopDbContext.Movies
            .Include(m => m.MovieGenres)
            .ThenInclude(mg => mg.Genre)
            .Include(m => m.Reviews)
            .Include(m => m.MovieCasts)
            .ThenInclude(mc => mc.Cast)
            .Include(m=>m.Trailers)
            .FirstOrDefault(m => m.Id == id) ?? throw new InvalidOperationException();
    }
}