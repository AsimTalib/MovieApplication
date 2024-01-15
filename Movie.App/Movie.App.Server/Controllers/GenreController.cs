using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using Movie.DAL.Context;
using Movie.DAL.Entities;
using Movie.Domain.Services;

namespace Movie.App.Server.Controllers
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [EnableQuery(PageSize = 50)] //odata one which is limited /odata/movie
        [HttpGet]
        public IQueryable<Genre> Get()
        {
            return _genreService.GetGenre().AsQueryable();
        }
    }
}
