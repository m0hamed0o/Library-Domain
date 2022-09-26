using Library_Domain;
using LibraryDataAccess;
using System;
using System.Text.Json;
using static System.Reflection.Metadata.BlobBuilder;

namespace LIbraryApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            // create data base
            using (LibraryDBContext context = new LibraryDBContext())
            {
                context.Database.EnsureCreated();
            }

            // create json file for users
            string users = File.ReadAllText("Users.json");
            var DefaultUsers = JsonSerializer.Deserialize<List<User>>(users);
            using (var Context = new LibraryDBContext())
            {
                Context.Users.AddRange(DefaultUsers);
                Context.SaveChanges();
            }

            // comparison username and password
            comparisonUsernameAndPassword();

            // number of books in Database
            GetNumberOfBooks();

            // Get information About the books
            GetInformation();
        }

        private static void GetInformation()
        {
            using (var context = new LibraryDBContext())
            {
                Console.Write("if you want information about all the booke enter 1 ," +
                    "               or if you want information about specific book inter 2" +
                    "               or if you want to delete book inter 3" +
                    "               or if you want to modify Title and price book inter 3  ");
                var info = Console.ReadLine();

                if (info == "1")
                {
                    foreach (var Book in Books)
                    {
                        Console.WriteLine(book.Id+" "+book.auther + " " book.NumberOfBooks);
                    }
                }
                if (info == "2")
                {
                    foreach (var book in Books)
                    {
                        Console.WriteLine(book.Auther + " " book.price);
                    }
                }
                if (info == "3")
                {
                    Console.WriteLine("inter number of book that you want to delete it ");
                    var num = Console.ReadLine();
                    
                }
                if (info == "4")
                {
                    Console.WriteLine("input number of book that you want to modify it");
                    var numberofbook = Console.ReadLine();

                    Console.WriteLine("input new title of book");
                    var newTitle = Console.ReadLine();

                    Console.WriteLine("input new price of book");
                    var newprice = Console.ReadLine();
                    
                }
            }
        }

        private static void GetNumberOfBooks()
        {
            using (var context = new LibraryDBContext())
            {
                var NumberOfBooks = 0;
                foreach (var book in Books)
                {
                    NumberOfBooks += book.books;
                }
                Console.WriteLine("There are in the stock " + NumberOfBooks+ " books");
            }
        }

        private static void comparisonUsernameAndPassword()
        {
            Console.Write("Input User Name : ");
            string userName = Console.ReadLine();

            using (var context = new LibraryDBContext())
            {
                var users = context.Users.ToList();
                foreach (var user in users)
                {
                    if (userName==user.UserName)
                    {
                        Console.Write("Input password : ");
                        string Password = Console.ReadLine();
                        if (Password==user.Password)
                        {
                            Console.WriteLine("logging . . . . . . . . . . . . . . . . . .");
                        }
                        else
                        {
                            Console.WriteLine("wrong password try again");
                        }
                    }
                    else
                    {
                        Console.WriteLine("wrong user name try again");
                    }
                }
            }

        }
    }
}