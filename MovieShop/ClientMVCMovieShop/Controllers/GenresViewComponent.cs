using ApplicationCore.Contracts.Service;
using ClientMVCMovieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientMVCMovieShop.Controllers
{
    public class GenresViewComponent : ViewComponent
    {
        private readonly IGenreService _genreService;

        public GenresViewComponent(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string? selectedGenre)
        {
            var genres = await _genreService.GetAllGenresAsync();
            var viewModel = new GenreSelectModel
            {
                Genres = genres.ToList(),
                SelectedGenre = selectedGenre
            };
            return View("GenreDropDown", viewModel);
        }
    }
}