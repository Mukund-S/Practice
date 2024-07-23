using ApplicationCore.Entity;
using ApplicationCore.Model.Response;

namespace ApplicationCore.Contracts.Service
{
    public interface IMovieService
    {
        Task<IEnumerable<MoviesResponseModel>> GetAllMovieDetailsAsync();
        Task<IEnumerable<Movies>> GetHighestGrossingMoviesAsync(int count);
        Task<MoviesResponseModel> GetMovieDetailsAsync(int id);
        Task<IEnumerable<MoviesResponseModel>> GetMoviesByGenreAsync(string genre);
        Task<PaginatedResultSet<MoviesResponseModel>> GetMoviesPageCommonAsync(string genre, int pageSize, int pageNumber);
    }
}