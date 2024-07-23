using ApplicationCore.Model.Response;

namespace ClientMVCMovieShop.Models;

public class GenreSelectModel
{
    public List<GenresResponseModel> Genres { get; set; }
    public string SelectedGenre { get; set; } // Ensure this is a string
}
