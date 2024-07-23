using ApplicationCore.Model.Response;

namespace ClientMVCMovieShop.Models;

public class HomePageViewModel
{
    public List<MovieCardModel> Movies { get; set; }
    public List<GenresResponseModel> Genres { get; set; }
    
    public MoviesResponseModel MovieDetails { get; set; }
    public int? SelectedGenreId { get; set; }
}  