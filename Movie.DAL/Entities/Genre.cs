using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.DAL.Entities
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        
        //realation between the genre table
        public virtual List<MovieGenre> MovieGenres { get; set;}
    }
}
