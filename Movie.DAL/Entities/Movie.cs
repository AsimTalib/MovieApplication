namespace Movie.DAL.Entities
{
    public class Movie : BaseEntity
    {
        public DateTime ReleaseDate { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }
        public decimal Popularity { get; set; }
        public int VoteCount { get; set; }
        public decimal VoteAverage { get; set; }
        public string OriginalLanguage { get; set; }
        public string PosterUrl { get; set; }

        //

        public virtual List<MovieGenre> MovieGenres { get; set; }

        //need to obatin the actor details from somewhere maybe a process later on 
        public virtual List<MovieActor> MovieActors { get; set; }
    }
}
