using ApplicationCore.Contracts.Repository;
using ApplicationCore.Contracts.Service;
using ApplicationCore.Model.Response;

namespace Infrastructure.Service;

public class GenreService: IGenreService
{
    private readonly IGenresRepository _genresRepository;

    public GenreService(IGenresRepository genresRepository)
    {
        _genresRepository = genresRepository;
    }
    
    public async Task<IEnumerable<GenresResponseModel>> GetAllGenresAsync()
    {
        var result = await _genresRepository.GetAllAsync();
        List<GenresResponseModel> genresResponseModels = new List<GenresResponseModel>();
        foreach (var item in result)
        {
            GenresResponseModel model = new GenresResponseModel
            {
                Id = item.Id,
                Name = item.Name
            };
            genresResponseModels.Add(model);
        }

        return genresResponseModels;
    }

}