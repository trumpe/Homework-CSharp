using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Movie
    {
        public string Title { get; set; }
        public Genre Genre { get; set; }
        public double Rating { get; set; }
        public double TicketPrice { get; set; }

        public Movie(string title, Genre genre, double rating)
        {
            Title = title;
            Genre = genre;

            if (rating >= 1 && rating <= 5)
            {
                Rating = rating;
            }
            else
            {
                throw new Exception($"Rating for {Title} should be a number from 1 to 5");
            }

            TicketPrice = Rating * 5;
        }
    }
}
