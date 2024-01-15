

using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Movie.DAL.Context;
using Movie.DAL.Entities;
using Movie.Domain.Services;
using System.Text.Json.Serialization;


//to get the edmodel
static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    //set the main table
    builder.EntitySet<Movie.DAL.Entities.Movie>("Movie");
    builder.EntitySet<Genre>("Genre");
    return builder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddScoped<IFilePrcoessService, FileProcessService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IGenreService, GenreService>();

//odata addingc
builder.Services.AddControllers()
    .AddOData(options => options
        .AddRouteComponents("odata", GetEdmModel())
        .Select()
        .Filter()
        .OrderBy()
        .SetMaxTop(20)
        .Count()
        .Expand())
        .AddJsonOptions(options =>
        {
            //common error recursive -- 
            //options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
        });


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddDbContext<MovieDbContext>(options =>
{
    options.UseInMemoryDatabase(databaseName: "MoviesDB");
});


var app = builder.Build();
//inmemoery data
DBSeeder.AddMoviesData(app);

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");


app.Run();
