using Movie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Services
{
    public interface IFilePrcoessService
    {
        bool ImportMovies(IEnumerable<MovieRecordModel> records);

    }
}
