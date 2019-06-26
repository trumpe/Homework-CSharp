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
        public static bool CheckStudent(List<Student> students, string username)
        {
            foreach (var student in students)
            {
                if (student.Username == username)
                    return true;
            }
            return false;
        }

        public static bool CheckUser(List<User> users, string username)
        {
            foreach (var user in users)
            {
                if (user.Username == username)
                    return true;
            }
            return false;
        }

        public static List<Subject> ListOfSubjects()
        {
            return new List<Subject>()
            {
                new Subject("Basic Programming Principles"),
                new Subject("HTML"),
                new Subject("CSS"),
                new Subject("Basic JavaScript"),
                new Subject("Advanced Javascript"),
                new Subject("Basic C#"),
                new Subject("Advanced C#"),
                new Subject("Database Development"),
            };
        }

        public static List<User> ListOfUsers()
        {
            return new List<User>()
            {
                new Admin("admin1", "admin1"),
                new Admin("admin2", "admin2"),

                new Trainer("trainer1", "trainer1"),
                new Trainer("trainer2", "trainer2"),

                new Student("student1", "student1"),
                new Student("student2", "student2"),
                new Student("student3", "student3"),
                new Student("student4", "student4"),
                new Student("student5", "student5")
            };
        }

        static void Main(string[] args)
        {
            List<User> users = ListOfUsers();
            List<Subject> allSubjects = ListOfSubjects();
            List<Student> students = users.Where(x => x.Role == Role.Student).Cast<Student>().ToList();

            students[0].Grades = new Dictionary<Subject, int>() { { allSubjects[0], 3 }, { allSubjects[2], 4 }, { allSubjects[4], 5 }, { allSubjects[6], 5 } };
            students[1].Grades = new Dictionary<Subject, int>() { { allSubjects[2], 4 }, { allSubjects[3], 4 }, { allSubjects[5], 4 }, { allSubjects[7], 5 } };
            students[2].Grades = new Dictionary<Subject, int>() { { allSubjects[1], 5 }, { allSubjects[2], 5 }, { allSubjects[3], 5 }, { allSubjects[4], 5 } };
            students[3].Grades = new Dictionary<Subject, int>() { { allSubjects[0], 3 }, { allSubjects[4], 5 }, { allSubjects[5], 5 }, { allSubjects[6], 3 } };
            students[4].Grades = new Dictionary<Subject, int>() { { allSubjects[3], 4 }, { allSubjects[5], 4 }, { allSubjects[6], 5 }, { allSubjects[7], 5 } };

            students[0].CurrentSubject = allSubjects[1];
            students[1].CurrentSubject = allSubjects[6];
            students[2].CurrentSubject = allSubjects[5];
            students[3].CurrentSubject = allSubjects[2];
            students[4].CurrentSubject = allSubjects[2];

            while (true)
            {

                Console.WriteLine("1. Please login or 2.Exit program");

                bool tryInput = int.TryParse(Console.ReadLine(), out int input);

                if (input == 2)
                {
                    break;
                }
                else if (input == 1)
                {
                    Console.Write("Username: ");
                    string username = Console.ReadLine();

                    Console.Write("Password: ");
                    string password = Console.ReadLine();

                    User user;

                    user = users.Where(x => x.Username == username).FirstOrDefault();

                    if (user == null)
                    {
                        Console.WriteLine("there is no user like this");
                        Console.ReadLine();
                    }
                    else if (user.Password != password)
                    {
                        Console.WriteLine("Wrong password");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine($"Hello {user.Username}");

                        #region RoleAdmin
                        if (user.Role == Role.Admin)
                        {
                            while (true)
                            {
                                Console.WriteLine("Choose 1. Add user  2. Remove user 3.Logout");

                                bool tryInputAdmin = int.TryParse(Console.ReadLine(), out int adminInput);

                                if (adminInput == 1)
                                {
                                    Console.WriteLine("Which type of user you want to add: 1.Admin 2.Trainer 3.Student");

                                    bool tryTypeOfUser = int.TryParse(Console.ReadLine(), out int typeOfUser);

                                    if (tryTypeOfUser && typeOfUser <= 3)
                                    {
                                        Console.Write("Enter new username: ");
                                        string newUsername = Console.ReadLine();
                                        Console.Write("Enter new password: ");
                                        string newPassword = Console.ReadLine();

                                        if (CheckUser(users, newUsername))
                                        {
                                            Console.WriteLine("Already exist this user please try again");
                                            typeOfUser = 0;
                                        }
                                        else if (typeOfUser == 1)
                                        {
                                            Admin newUser = new Admin(newUsername, newPassword);
                                            users.Add(newUser);
                                        }
                                        else if (typeOfUser == 2)
                                        {
                                            Trainer newUser = new Trainer(newUsername, newPassword);
                                            users.Add(newUser);
                                        }
                                        else if (typeOfUser == 3)
                                        {
                                            Student newUser = new Student(newUsername, newPassword);
                                            var random = new Random();
                                            newUser.Grades = new Dictionary<Subject, int>() { { allSubjects[random.Next(0, allSubjects.Count - 1)], random.Next(1, 6) } };
                                            users.Add(newUser);
                                            students.Add(newUser);
                                        }
                                    }
                                    else
                                        Console.WriteLine("wrong input");
                                }
                                else if (adminInput == 2)
                                {
                                    Console.WriteLine();
                                    foreach (var item in users)
                                    {
                                        Console.WriteLine(item.Username);
                                    }
                                    Console.Write("Enter username you want to remove: ");
                                    string userWantToRemove = Console.ReadLine();

                                    if (userWantToRemove == user.Username)
                                    {
                                        Console.WriteLine("Admins cant remove it self");
                                    }
                                    else if (CheckUser(users, userWantToRemove))
                                    {
                                        User userRemove = users.Where(x => x.Username == userWantToRemove).FirstOrDefault();
                                        if (userRemove.Role == Role.Student)
                                        {
                                            Student studentRemove = (Student)userRemove;
                                            students.Remove(studentRemove);
                                        }
                                        users.Remove(userRemove);
                                    }
                                    else
                                        Console.WriteLine($"Doesn't exist user like {userWantToRemove}");
                                }
                                else if (adminInput == 3)
                                    break;
                                else
                                    Console.WriteLine("wrong input");

                                Console.WriteLine("Press enter");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        #endregion

                        #region RoleTrainer
                        if (user.Role == Role.Trainer)
                        {
                            while (true)
                            {
                                Console.WriteLine();
                                Console.WriteLine("1.Show all students  2.Show all subjects 3.Logout");
                                
                                bool tryInputTrainer = int.TryParse(Console.ReadLine(), out int trainerInput);

                                if (trainerInput == 1)
                                {
                                    foreach (var student in students)
                                    {
                                        Console.WriteLine(student.Username);
                                    }
                                    Console.WriteLine();
                                    Console.WriteLine("Enter student to show its subjects and grades");
                                    Console.Write("Student: ");
                                    string studentInput = Console.ReadLine();

                                    if (CheckStudent(students, studentInput))
                                    {
                                        Student student = students.Where(x => x.Username == studentInput).FirstOrDefault();
                                        foreach (var studentSubject in student.Grades)
                                        {
                                            Console.WriteLine($"{studentSubject.Key.Name} / Grade: {studentSubject.Value}");
                                        }
                                    }
                                    else
                                        Console.WriteLine($"There is no student like {studentInput}");
                                }
                                else if (trainerInput == 2)
                                {
                                    foreach (var subject in allSubjects)
                                    {
                                        subject.StudentsListen = students.Where(x => x.CurrentSubject.Name == subject.Name).ToList();
                                        Console.WriteLine($"{subject.Name} / listening : {subject.StudentsListen.Count}");
                                    }
                                }
                                else if (trainerInput == 3)
                                    break;
                                else
                                    Console.WriteLine("wrong input");


                                Console.WriteLine("Press enter");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        #endregion

                        #region RoleStudent
                        if (user.Role == Role.Student)
                        {
                            while (true)
                            {
                                Console.WriteLine("Choose: 1.Show your subjects and grades  2.Logout");
                                
                                bool tryInputTrainer = int.TryParse(Console.ReadLine(), out int studentInput);

                                Student student = students.Where(x => x.Username == user.Username).FirstOrDefault();

                                if (studentInput == 1)
                                {
                                    foreach (var item in student.Grades)
                                    {
                                        Console.WriteLine($"{item.Key.Name} / Grade: {item.Value}");
                                    }
                                }
                                else if (studentInput == 2)
                                    break;
                                else
                                    Console.WriteLine("wrong input");

                                Console.WriteLine("Press enter");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        #endregion
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input");
                    Console.ReadLine();
                }
                Console.Clear();
            }
        }
    }
}
