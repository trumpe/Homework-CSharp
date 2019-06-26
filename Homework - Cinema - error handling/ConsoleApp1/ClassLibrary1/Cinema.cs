using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Cinema
    {
        public string Name { get; set; }
        public List<int> Halls { get; set; }
        public List<Movie> ListOfMovies { get; set; }

        public Cinema(string name, List<int> halls, List<Movie> movies)
        {
            Name = name;
            Halls = halls;
            ListOfMovies = movies;
        }

        public void MoviePlaying(Movie movie)
        {
            Console.WriteLine();
            Console.WriteLine($"Watching {movie.Title}...");
        }
    }
}
