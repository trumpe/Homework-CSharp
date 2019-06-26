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
        static void Main(string[] args)
        {
            var people = new List<Person>()
            {
                new Person("Nathanael", "Holt", 20, Job.Choreographer),
                new Person("Jabari", "Chapman", 35, Job.Dentist),
                new Person("Oswaldo", "Wilson", 19, Job.Developer),
                new Person("Kody", "Walton", 43, Job.Sculptor),
                new Person("Andreas", "Weeks", 17, Job.Developer),
                new Person("Kayla", "Douglas", 28, Job.Developer),
                new Person("Xander", "Campbell", 19, Job.Waiter),
                new Person("Soren", "Velasquez", 33, Job.Interpreter),
                new Person("August", "Rubio", 21, Job.Developer),
                new Person("Malakai", "Mcgee", 57, Job.Barber),
                new Person("Emerson", "Rollins", 42, Job.Choreographer),
                new Person("Everett", "Parks", 39, Job.Sculptor),
                new Person("Amelia", "Moody", 24, Job.Waiter),
                new Person("Emilie", "Horn", 16, Job.Waiter),
                new Person("Leroy", "Baker", 44, Job.Interpreter),
                new Person("Nathen", "Higgins", 60, Job.Archivist),
                new Person("Erin", "Rocha", 37, Job.Developer),
                new Person("Freddy", "Gordon", 26, Job.Sculptor),
                new Person("Valeria", "Reynolds", 26, Job.Dentist),
                new Person("Cristofer", "Stanley", 28, Job.Dentist)
            };

            var dogs = new List<Dog>()
            {
                new Dog("Charlie", "Black", 3, Race.Collie),
                new Dog("Buddy", "Brown", 1, Race.Doberman),
                new Dog("Max", "Olive", 1, Race.Plott),
                new Dog("Archie", "Black", 2, Race.Mutt),
                new Dog("Oscar", "White", 1, Race.Mudi),
                new Dog("Toby", "Maroon", 3, Race.Bulldog),
                new Dog("Ollie", "Silver", 4, Race.Dalmatian),
                new Dog("Bailey", "White", 4, Race.Pointer),
                new Dog("Frankie", "Gray", 2, Race.Pug),
                new Dog("Jack", "Black", 5, Race.Dalmatian),
                new Dog("Chanel", "Black", 1, Race.Pug),
                new Dog("Henry", "White", 7, Race.Plott),
                new Dog("Bo", "Maroon", 1, Race.Boxer),
                new Dog("Scout", "Olive", 2, Race.Boxer),
                new Dog("Ellie", "Brown", 6, Race.Doberman),
                new Dog("Hank", "Silver", 2, Race.Collie),
                new Dog("Shadow", "Silver", 3, Race.Mudi),
                new Dog("Diesel", "Brown", 1, Race.Bulldog),
                new Dog("Abby", "Black", 1, Race.Dalmatian),
                new Dog("Trixie", "White", 8, Race.Pointer),
            };

            //Add dogs to persons

            Person cristofer = (from person in people
                                 where person.FirstName == "Cristofer"
                                 select person).FirstOrDefault();
            cristofer.Dogs = (from dog in dogs
                               where dog.Name == "Jack" || dog.Name == "Ellie" || dog.Name == "Hank"
                               select dog).ToList();

            Person freddy = (from person in people
                                where person.FirstName == "Freddy"
                                select person).FirstOrDefault();
            freddy.Dogs = (from dog in dogs
                            where dog.Name == "Oscar" || dog.Name == "Toby" || dog.Name == "Chanel" || dog.Name == "Bo" || dog.Name == "Scout"
                            select dog).ToList();

            Person erin = (from person in people
                             where person.FirstName == "Erin"
                             select person).FirstOrDefault();
            erin.Dogs = (from dog in dogs
                           where dog.Name == "Trixie" || dog.Name == "Archie" || dog.Name == "Max"
                           select dog).ToList();

            Person amelia = (from person in people
                           where person.FirstName == "Amelia"
                           select person).FirstOrDefault();
            amelia.Dogs = (from dog in dogs
                           where dog.Name == "Abby" || dog.Name == "Shadow"
                           select dog).ToList();

            //People firstnames starting with R ordered by Age - DESCENDING ORDER

            Console.WriteLine("People firstnames starting with R: ");

            var peopleNameStartsWithR = (from person in people
                                         where person.FirstName.StartsWith("R")
                                         orderby person.Age descending
                                         select person).ToList();

            foreach (var item in peopleNameStartsWithR)
            {
                Console.WriteLine(item.FirstName);
            }

            //Brown dogs older than 3 years ordered by Age - ASCENDING ORDER
            Console.WriteLine();
            Console.WriteLine("Brown dogs older than 3: ");

            var brownDogsOlderThanThree = (from dog in dogs
                                           where dog.Color == "Brown" && dog.Age > 3
                                           orderby dog.Age ascending
                                           select dog).ToList();

            foreach (var item in brownDogsOlderThanThree)
            {
                Console.WriteLine(item.Name);
            }

            //People with more than 2 dogs ordered by Name - DESCENDING ORDER
            Console.WriteLine();
            Console.WriteLine("People with more than 2 dogs: ");
            var peopleWithMoreThanTwoDogs = (from person in people
                                             where person.Dogs.Count > 2
                                             orderby person.FirstName descending
                                             select person).ToList();

            foreach (var item in peopleWithMoreThanTwoDogs)
            {
                Console.WriteLine(item.FirstName);
            }

            //Freddy dogs older than 1 year
            Console.WriteLine();
            Console.WriteLine("Freddy dogs older than 1: ");
            
            var freddyDogsOlderThanOne = (from dog in freddy.Dogs
                                          where dog.Age > 1
                                          select dog).ToList();

            foreach (var item in freddyDogsOlderThanOne)
            {
                Console.WriteLine(item.Name);
            }

            //Nathen first dog
            Console.WriteLine();
            Console.WriteLine("Nathen first dog: ");
            
            var nathen = (from person in people
                          where person.FirstName == "Nathen"
                          select person).FirstOrDefault();

            if (nathen.Dogs.Count > 0)
            {
                Console.WriteLine(nathen.Dogs.First().Name);

            }
            else
            {
                Console.WriteLine("Nathen hasnt dogs");
            }

            //All white dogs from cristofer, freddy, erin and amellia ordered by Name - ASCENDING ORDER
            Console.WriteLine();
            Console.WriteLine("All white dogs from cristofer, freddy, erin and amellia");
            var cristoferFreddyErinAmelliaDogs = new List<Dog>();

            foreach (var item in cristofer.Dogs)
            {
                cristoferFreddyErinAmelliaDogs.Add(item);
            }
            foreach (var item in freddy.Dogs)
            {
                cristoferFreddyErinAmelliaDogs.Add(item);
            }
            foreach (var item in erin.Dogs)
            {
                cristoferFreddyErinAmelliaDogs.Add(item);
            }
            foreach (var item in amelia.Dogs)
            {
                cristoferFreddyErinAmelliaDogs.Add(item);
            }

            var allWhiteDogs = (from dog in cristoferFreddyErinAmelliaDogs
                                where dog.Color == "White"
                                orderby dog.Name ascending
                                select dog).ToList();

            foreach (var item in allWhiteDogs)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
