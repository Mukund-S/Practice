using System.Diagnostics;
using ApplicationCore.Contracts.Service;
using ApplicationCore.Entity;
using ApplicationCore.Model.Response;
using Microsoft.AspNetCore.Mvc;
using ClientMVCMovieShop.Models;

namespace ClientMVCMovieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IMovieService movieService, IGenreService genreService)
        {
            _logger = logger;
            _movieService = movieService;
            _genreService = genreService;
        }

        public async Task<IActionResult> Index(string genre, int pageSize = 30, int pageNumber = 1)
        {
            PaginatedResultSet<MoviesResponseModel> result = await _movieService.GetMoviesPageCommonAsync(genre, pageSize, pageNumber);

            var movieCardModels = result.Items.Select(movie => new MovieCardModel
            {
                Id = movie.Id,
                PosterUrl = movie.PosterUrl
            }).ToList();

            var paginatedResult = new PaginatedResultSet<MovieCardModel>
            {
                Items = movieCardModels,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize,
                TotalItems = result.TotalItems
            };

            ViewBag.SelectedGenre = genre;

            return View("Index", paginatedResult);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
