using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SocialNetworkApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();

            do
            {
                Console.WriteLine("Hello! You have the following Options: \n\n"
              + "Press 1: Your Wall\n"
              + "Press 2: Feed \n"
              + "Press 3: Create post \n"
              + "Press 4: Create Comment \n\n"
);
                Console.Write("Enter Number: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        var obj1 = new Command();
                        Console.WriteLine("Write UserId");
                        var LoggedInUserID = Console.ReadLine();
                        obj1.ShowFeed(LoggedInUserID);
                        break;

                    case "2":
                        var obj2 = new Command();
                        Console.WriteLine("Write UserID");
                        var UserID = Console.ReadLine();
                        Console.WriteLine("Write GuestID");
                        var GuestID = Console.ReadLine();
                        obj2.ShowWall(UserID, GuestID);
                        break;

                    case "3":
                        var obj3 = new Command();
                        Console.WriteLine("Write OwnerID");
                        var OwnerID = Console.ReadLine();
                        Console.WriteLine("Write Content");
                        var Content = Console.ReadLine();
                        Console.WriteLine("Write Circle");
                        string Circle = Console.ReadLine();
                        Console.WriteLine("Decide privacy");
                        string privacy = Console.ReadLine();
                        obj3.CreatePost(OwnerID, Content, Circle, privacy);
                        break;

                    case "4":
                        var obj4 = new Command();
                        Console.WriteLine("Write PostID");
                        var PostID = Console.ReadLine();
                        Console.WriteLine("Write Comment");
                        var Comment = Console.ReadLine();
                        obj4.CreateComment(PostID, Comment);
                        break;
                }

            } while (true);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
       
    }
}
