using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FilesAndObjects
{
    class Program
    {
        class Movie
        {
            public string title;
            public string rating;
            public string year;

            public Movie(string _title, string _rating, string _year)
            {
                title = _title;
                rating = _rating;
                year = _year;
            }
        }
        static void Main(string[] args)
        {
            string filepath = @"C:\Users\mammu\samples";
            string filename = @"imdb.txt";
            List<string> movieList = File.ReadAllLines(Path.Combine(filepath, filename)).ToList();
            List<Movie> listOfMovies = new List<Movie>();



            foreach (string movieItem in movieList)
            {
                string[] tempArray = movieItem.Split(new char[] {';'},StringSplitOptions.RemoveEmptyEntries);
                Movie newMovie = new Movie(tempArray[0],tempArray[1],tempArray[2]);

                listOfMovies.Add(newMovie);
            }

            foreach (Movie movie in listOfMovies)
            {
                Console.WriteLine($"Title: {movie.title}; Rating: {movie.rating}; Year: {movie.year}");
            }

            Console.WriteLine("What`s your favourite movie? enter title:");
            string favMovieTitle = Console.ReadLine();
            Console.WriteLine("Enter the rating of your favourite movie:");
            string favMovieRating = Console.ReadLine();
            Console.WriteLine("Enter release year");
            string favMovieYear = Console.ReadLine();
            
            Movie favMovie = new Movie(favMovieTitle, favMovieRating, favMovieYear);
            string favMovieLine = $"{favMovie.title};{favMovie.rating};{favMovie.year}";

            movieList.Add(favMovieLine);
            File.WriteAllLines(Path.Combine(filepath, filename), movieList);
        }
    }
}
