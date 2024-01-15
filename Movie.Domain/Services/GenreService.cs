using Microsoft.EntityFrameworkCore;
using Movie.DAL.Context;
using Movie.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Services
{
    public class GenreService : IGenreService
    {
        private readonly MovieDbContext _dbContext;
        public GenreService(MovieDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IQueryable<Genre> GetGenre()
        {
            return _dbContext.Genres
                    .Include(x => x.MovieGenres)
                        .ThenInclude(x => x.Movie)
                    .AsQueryable();
        }
    }
}
