using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Service;
using ApplicationCore.Entity;
using ApplicationCore.Model.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        //HomeController
        public async Task<IEnumerable<Movies>> GetHighestGrossingMoviesAsync(int count)
        {
            var movies = await _movieRepository.GetAllAsync();
            return movies.OrderByDescending(movie => movie.Revenue).Take(count).ToList();
        }
        public async Task<IEnumerable<MoviesResponseModel>> GetAllMovieDetailsAsync()
        {
            var movies = await _movieRepository.GetAllAsync();
            if (movies == null)
            {
                return new List<MoviesResponseModel>();
            }
            return movies.Select(movie => new MoviesResponseModel
            {
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
            }).ToList();
        }
        
        public async Task<IEnumerable<MoviesResponseModel>> GetMoviesByGenreAsync(string genre)
        {
            var movies = await _movieRepository.GetByGenreAsync(genre);
            if (movies == null)
            {
                return new List<MoviesResponseModel>();
            }
            return movies.Select(movie => new MoviesResponseModel
            {
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
            }).ToList();
            
        }
        public async Task<PaginatedResultSet<MoviesResponseModel>> GetMoviesPageCommonAsync(string genre, int pageSize, int pageNumber)
        {
            var allMovies = string.IsNullOrEmpty(genre) ? 
                await GetAllMovieDetailsAsync() : 
                await GetMoviesByGenreAsync(genre);
           
            var totalItems = allMovies.Count();
            var moviesToReturn = allMovies
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PaginatedResultSet<MoviesResponseModel>
            {
                Items = moviesToReturn,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItems = totalItems
            };
        }

        // MoviesController
        public async Task<MoviesResponseModel> GetMovieDetailsAsync(int id)
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            if (movie == null) return null;

            return new MoviesResponseModel
            {
                Id = movie.Id,
                BackdropUrl = movie.BackdropUrl,
                Budget = movie.Budget,
                CreatedBy = movie.CreatedBy,
                CreatedDate = movie.CreatedDate,
                ImdbUrl = movie.ImdbUrl,
                OriginalLanguage = movie.OriginalLanguage,
                Overview = movie.Overview,
                PosterUrl = movie.PosterUrl,
                Price = movie.Price,
                ReleaseDate = movie.ReleaseDate,
                Revenue = movie.Revenue,
                RunTime = movie.RunTime,
                Tagline = movie.Tagline,
                Title = movie.Title,
                TmdbUrl = movie.TmdbUrl,
                UpdatedBy = movie.UpdatedBy,
                UpdatedDate = movie.UpdatedDate,
                Genres = movie.MovieGenres?.Select(mg => new GenresResponseModel
                {
                    Id = mg.Genre.Id,
                    Name = mg.Genre.Name
                }).ToList(),
                Reviews = movie.Reviews?.Select(r => new ReviewsResponseModel
                {
                    Id = r.MovieId,
                    ReviewText = r.ReviewText,
                    Rating = r.Rating
                }).ToList(),
                Casts = movie.MovieCasts?.Select(mc => new CastResponseModel
                {
                    Id = mc.Cast.Id,
                    Gender = mc.Cast.Gender,
                    Name = mc.Cast.Name,
                    ProfilePath = mc.Cast.ProfilePath,
                    TmdbUrl = mc.Cast.TmdbUrl,
                    Character = mc.Character
                }).ToList(),
                Trailers = movie.Trailers?.ToList(),
                Favorites = movie.Favorites?.ToList(),
                Purchases = movie.Purchases?.ToList()
            };
        }

    }
}
