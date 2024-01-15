using Movie.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Services
{
    public interface IGenreService
    {
        IQueryable<Genre> GetGenre();
    }
}
