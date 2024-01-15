using Microsoft.EntityFrameworkCore;
using Movie.DAL.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Services
{
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _dbContext;
        public MovieService(MovieDbContext dbContext) 
        {
            _dbContext = dbContext;
        }
        public IQueryable<Movie.DAL.Entities.Movie> GetMovies()
        {
            return _dbContext.Movies
                    .Include(x => x.MovieGenres)
                        .ThenInclude(x => x.Genre)
                    .Include(x => x.MovieActors)
                        .ThenInclude(x => x.Actor)
                    .AsQueryable();
        }
    }
}
