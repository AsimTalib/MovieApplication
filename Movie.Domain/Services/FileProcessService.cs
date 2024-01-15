using Microsoft.EntityFrameworkCore;
using Movie.DAL.Context;
using Movie.DAL.Entities;
using Movie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Domain.Services
{
    public class FileProcessService : IFilePrcoessService
    {
        private MovieDbContext _dbContext;
        public FileProcessService(MovieDbContext dbContext) { 
           _dbContext = dbContext;
        }
        public bool ImportMovies(IEnumerable<MovieRecordModel> records)
        {
            try
            {
                foreach(MovieRecordModel record in records)
                {
                    var movie = new Movie.DAL.Entities.Movie
                    {
                        Title = record.Title,
                        Overview = record.Overview,
                        Popularity = record.Popularity,
                        VoteCount = record.Vote_Count,
                        VoteAverage = record.Vote_Average,
                        OriginalLanguage = record.Original_Language,        
                        ReleaseDate = record.Release_Date,
                        PosterUrl = record.Poster_Url,

                    };

                    var actor = new Actor
                    {
                        Name = "Leornado Dicaprio"
                    };

                    var actorMovie = new MovieActor
                    {
                         Actor = actor,
                         Movie = movie,
                    };

                    
                    _dbContext.Actors.Add(actor);
                    _dbContext.Movies.Add(movie);
                    _dbContext.MovieActors.Add(actorMovie);

                   // await _dbContext.SaveChangesAsync();

                    foreach (var genre in record.Genre.Split(','))
                    {
                        var singleGenre = new Genre
                        {
                            Name = genre
                        };
                        _dbContext.Genres.Add(singleGenre);

                        _dbContext.MovieGenres.Add(new MovieGenre
                        {
                            Movie = movie,
                            Genre = singleGenre
                        });
                       // await _dbContext.SaveChangesAsync();
                    };
                    _dbContext.SaveChanges();
                };

            }catch (Exception ex)
            {

            }
            return true;
        }
    }
}
