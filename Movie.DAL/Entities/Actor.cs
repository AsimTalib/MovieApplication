using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.DAL.Entities
{
    public class Actor : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<MovieActor> MovieActors { get; set;}

    }
}
