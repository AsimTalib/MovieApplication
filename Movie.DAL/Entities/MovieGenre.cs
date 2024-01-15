using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.DAL.Entities
{
    public class MovieGenre : BaseEntity
    {
        public int GenreId { get; set; }
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        //relation to the genre table from the movie table
        public virtual Genre Genre { get; set; }
    }
}
