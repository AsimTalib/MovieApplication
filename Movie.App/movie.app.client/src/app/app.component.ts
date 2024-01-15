import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: Date;
  TemperatureC: number;
  TemperatureF: number;
  Summary: string;
    
}
interface Movie {
  releaseDate: Date;
  title: string;
  overview: string;
  popularity: number;
  voteCount: number;
  voteAverage: number;
  originalLanguage: string;
  posterUrl: string;
  movieGenres: string;
  actorGenres: string;
}
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public weatherforcasts: WeatherForecast[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getMovies();
  }

   getMovies() {
     this.http.get<WeatherForecast[]>('/movie').subscribe(
       (result) => {
         this.weatherforecasts = result;
       },
       (error) => {
         console.error(error);
         console.log("jdkhkashd");
       }
     );
   }

  title = 'movie.app.client';
}
