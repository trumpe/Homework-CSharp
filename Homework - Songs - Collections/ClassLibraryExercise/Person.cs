using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryExercise
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Genre FavoriteMusicType { get; set; }
        public List<Song> FavoriteSongs { get; set; }

        public Person(string firstName, string lastName, int age, Genre genre)
        {
            Id = new Random().Next(10000, 99999);
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            FavoriteMusicType = genre;
            FavoriteSongs = new List<Song>();
        }

        public void GetFavoriteSongs()
        {
            if (FavoriteSongs.Count > 0)
            {
                Console.WriteLine($"{FirstName} favorites songs");
                foreach (var item in FavoriteSongs)
                {
                    Console.WriteLine($"{item.Title}/ {item.Genre}/ {item.Length}");
                }
            }
            else
            {
                Console.WriteLine($"{FirstName} hasnt favorite songs");
            }

        }
    }
}
