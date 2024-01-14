# MovieApplication
The application conists of a backend API which contains movie details and a front end which displays the data (Under construction) 
The backend is built in .Net 6 using entityFramework and oData which follows a domain driven design 
The solution also contains docker images for the backend and the frontend for future deployments 

The design of the entities is displayed within the diagram below
![image](https://github.com/AsimTalib/MovieApplication/assets/45314664/36dfea04-1b8e-4475-a552-d33f0d6eba63)

The data was downloaded from kaggle movie set data (https://www.kaggle.com/datasets/disham993/9000-movies-dataset?resource=download) -- it is advised to clean this data again as it has some rows which causes errors. The data does not contain actor data.

The text below show the requirements and how they are met with examples of the API calls:

Must have(s)

“As a user I want to search movies by title/name”

https://localhost:7051/odata/Movie?$filter=Title eq 'Spider-Man: No Way Home'&$expand=MovieGenres($expand=Genre)
https://localhost:7051/odata/Movie?$filter=Title eq 'Spider-Man: No Way Home'&$expand=MovieGenres($expand=Genre)&$expand=MovieActors($expand=Actor)
https://localhost:7051/odata/Movie?$filter=Title eq 'Spider-Man: No Way Home'

“As a user I want to be able to limit the number of results per search”

https://localhost:7051/odata/Movie?$expand=MovieGenres($expand=Genre)&$expand=MovieActors($expand=Actor)&$top=10

“As a user I want to be able to ‘page’ through the list of movies”

https://localhost:7051/odata/Movie?$expand=MovieGenres($expand=Genre)&$expand=MovieActors($expand=Actor)&$top=1&$skip=4
https://localhost:7051/odata/Movie?$expand=MovieGenres($expand=Genre)&$expand=MovieActors($expand=Actor)&$top=20&$skip=10

Should have(s)

“As a user I want to filter movies by genre”

https://localhost:7051/odata/Genre?$expand=MovieGenres($expand=Movie)&filter=Name eq 'Adventure'

Could have(s)

“As a user I want to filter movies by actors” 

Not possible as a hard coded value was put in for all movies

“As a user I want to be able to sort movies by title/name or release date”

https://localhost:7051/odata/Movie?$orderby=Title desc
https://localhost:7051/odata/Movie?$orderby=Title asc

