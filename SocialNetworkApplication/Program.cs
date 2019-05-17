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
                        Command.ShowFeed();
                        break;

                    case "2":
                        Command.ShowWall();
                        break;

                    case "3":
                        Console.WriteLine("Write OwnerID");
                        var OwnerID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write Content");
                        var Content = Console.ReadLine();
                        Console.WriteLine("Write Circle");
                        string Circle = Console.ReadLine();
                        Command.CreatePost(OwnerID, Content, Circle);
                        break;

                    case "4":
                        Console.WriteLine("Write PostID");
                        var PostID = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Write Comment");
                        var Comment = Console.ReadLine();
                        Command.CreateComment(PostID, Comment);
                        break;
                }

            } while (true);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
       
    }
}
