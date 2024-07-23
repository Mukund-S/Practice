using ApplicationCore.Contracts.Service;
using ApplicationCore.Model.Response;
using ClientMVCMovieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientMVCMovieShop.Controllers;

public class MoviesController: Controller
{
    private readonly IMovieService _movieService;

    public MoviesController(IMovieService movieService)
    {
        _movieService = movieService;
    }
    
    public async Task<IActionResult> Details(int id)
    {
        var result = await _movieService.GetMovieDetailsAsync(id);
        return View(result);
    }
    
    
    
}