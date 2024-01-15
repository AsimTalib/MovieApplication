using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Movie.DAL.Context;
using Movie.DAL.Entities;
using Movie.Domain.Services;

namespace Movie.App.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]//gets everything /api/movie
    public class MovieController : ControllerBase
    {
        
        private readonly IMovieService _movieService;
        public MovieController(IMovieService movieService ) 
        {   
            _movieService = movieService;
        }



        [EnableQuery(PageSize = 50)] //odata one which is limited /odata/movie
        [HttpGet]
        public IQueryable<Movie.DAL.Entities.Movie> Get()
        {
            return _movieService.GetMovies();
        }

    }
}
