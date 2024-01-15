using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Models
{
    public class MovieRecordModel
    {
        public DateTime Release_Date { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public decimal Popularity { get; set; }
        public int Vote_Count { get; set; }
        public decimal Vote_Average { get; set; }
        public string Original_Language { get; set; }
        public string Genre { get; set; }
        public string Poster_Url { get; set; }
    }
}
