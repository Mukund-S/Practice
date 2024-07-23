using ApplicationCore.Model.Response;

namespace ApplicationCore.Contracts.Service;

public interface IGenreService
{
    Task<IEnumerable<GenresResponseModel>> GetAllGenresAsync();
}