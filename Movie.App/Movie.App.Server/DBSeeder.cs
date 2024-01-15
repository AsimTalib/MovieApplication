using CsvHelper;
using Movie.DAL.Context;
using Movie.Domain.Models;
using Movie.Domain.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class DBSeeder {
        public static void AddMoviesData(WebApplication app)
        {
            var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetService<MovieDbContext>();
            var fileService = scope.ServiceProvider.GetService<IFilePrcoessService>();

        // Assuming you have Movie, Actor, and MovieActor classes and a DbContext named 'db'
        using (var reader = new StreamReader("mymoviedb.csv"))
        {
            //invariant is uk and it gets used if any langauge gets translated
            using (var csv = new CsvReader(reader, System.Globalization.CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<MovieRecordModel>();

                var result =  fileService.ImportMovies(records);
            }
        }
        
    }
    }