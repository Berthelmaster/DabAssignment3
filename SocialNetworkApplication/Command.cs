using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace SocialNetworkApplication
{
    public class Command
    {
        public static void ShowFeed()
        {
            

            Console.WriteLine("All current feeds");




        }

        public static void ShowWall()
        {
            
        }

        public static void CreatePost(int OwnerID, string Contnet, string Circle)
        {

        }

        public static void CreateComment(int PostID, string Comment)
        {

        }

    }
}
