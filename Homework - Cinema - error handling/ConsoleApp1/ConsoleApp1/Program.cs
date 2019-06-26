using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using ClassLibrary1;

namespace ConsoleApp1
{
    class Program
    {
        public void GenerateByGenre(List<Movie> movies)
        {
            foreach (var item in movies)
            {
                Console.WriteLine($"{item.Title} - {item.Genre}");
            }
        }
        static void Main(string[] args)
        {
            Movie movie1 = new Movie("Scary Movie", Genre.Comedy, 6.6);
            Movie movie2 = new Movie("American Pie", Genre.Comedy, 2.5);
            Movie movie3 = new Movie("Saw", Genre.Horror, 1.9);
            Movie movie4 = new Movie("The Shining", Genre.Horror, 4.3);
            Movie movie5 = new Movie("Rambo", Genre.Action, 3.2);
            Movie movie6 = new Movie("The Terminator", Genre.Action, 4.1);
            Movie movie7 = new Movie("Forrest Gump", Genre.Drama, 4.9);
            Movie movie8 = new Movie("12 Angru Men", Genre.Drama, 4.6);
            Movie movie9 = new Movie("Passengers", Genre.SciFi, 3.7);
            Movie movie10 = new Movie("Interstellar", Genre.SciFi, 3.3);

            List<Movie> movies = new List<Movie>() { movie1, movie2, movie3, movie4, movie5, movie6, movie7, movie8, movie9, movie10 };

            var movies2 = (from movie in movies
                           where movie.Rating > 4
                           select movie).ToList();

            var movies3 = (from movie in movies
                           where movie.Genre == Genre.Horror || movie.Genre == Genre.SciFi
                           select movie).ToList();


            Cinema cinema1 = new Cinema("cineplex1", new List<int> { 1, 2, 3, 4, }, movies);
            Cinema cinema2 = new Cinema("cineplex2", new List<int> { 1, 2, 3, 4, }, movies2);
            Cinema cinema3 = new Cinema("cineplex3", new List<int> { 1, 2, 3 }, movies3);

            List<Cinema> cinemas = new List<Cinema>() { cinema1, cinema2, cinema3 };

            try
            {
                Console.WriteLine("Choose cinema you want to go");

                foreach (var cinema in cinemas)
                {
                    Console.WriteLine(cinema.Name);
                }

                Console.Write("Cinema: ");
                string input = Console.ReadLine();

                if (input != "cineplex1" && input != "cineplex2" && input != "cineplex3")
                    throw new Exception("You must enter valid cinema");

                var cinemaYouWantToGo = (from cinema in cinemas
                                         where cinema.Name == input
                                         select cinema).FirstOrDefault();

                Console.WriteLine("Do you want  1. all movies or  2.by genre");
                string input2 = Console.ReadLine();

                if (input2 == "1")
                {
                    Console.WriteLine("Choose movie you want to watch");

                    foreach (var item in cinemaYouWantToGo.ListOfMovies)
                    {
                        Console.WriteLine($"{item.Title} - {item.Genre} / {item.TicketPrice}");
                    }
                }
                else if (input2 == "2")
                {
                    Console.WriteLine("Enter your favorite genre");

                    foreach (var item in cinemaYouWantToGo.ListOfMovies)
                        Console.WriteLine(item.Genre);

                    Console.WriteLine();
                    Console.Write("Genre: ");
                    string inputGenre = Console.ReadLine().ToLower();

                    Genre favoriteGenre = new Genre();

                    switch (inputGenre)
                    {
                        case "action":
                            favoriteGenre = Genre.Action;
                            break;
                        case "horror":
                            favoriteGenre = Genre.Horror;
                            break;
                        case "comedy":
                            favoriteGenre = Genre.Comedy;
                            break;
                        case "drama":
                            favoriteGenre = Genre.Drama;
                            break;
                        case "scifi":
                            favoriteGenre = Genre.SciFi;
                            break;
                        default:
                            throw new Exception("You enter wrong genre");
                    }

                    Console.WriteLine("Choose movie you want to watch");
                    var moviesByGenre = (from movie in cinemaYouWantToGo.ListOfMovies
                                         where movie.Genre == favoriteGenre
                                         select movie).ToList();

                    foreach (var item in moviesByGenre)
                        Console.WriteLine($"{item.Title} - {item.Genre} / {item.TicketPrice} $");
                }
                else
                {
                    throw new Exception("You must enter 1 or 2");
                }

                Console.WriteLine();
                Console.Write("Movie: ");
                string movieToWatch = Console.ReadLine().ToLower();

                var watchingMovie = (from movie in cinemaYouWantToGo.ListOfMovies
                                     where movie.Title.ToLower() == movieToWatch
                                     select movie).FirstOrDefault();

                cinemaYouWantToGo.MoviePlaying(watchingMovie);
            }

            catch (NullReferenceException)
            {
                Console.WriteLine("You entered wrong movie");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}
