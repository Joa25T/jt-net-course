using System.Data;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Client;


namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Computer myComp = new Computer()
            {
                Motherboard ="Inteli7",
                CPUCores = 12,
                HasWifi = true,
                ReleaseDate = DateTime.Now,
                Price = 99.99m,
                VideoCard = "Nvidia OrSOMT"

            };

            string sql = @"INSERT INTO TutorialAppSchema.Computer (
                Motherboard,
                CPUCores,
                HasWifi,
                ReleaseDate,
                Price,
                VideoCard
                ) VALUES ('" + myComp.Motherboard 
                     + "','" + myComp.CPUCores
                     + "','" + myComp.HasWifi
                     + "','" + myComp.ReleaseDate
                     + "','" + myComp.Price
                     + "','" + myComp.VideoCard + "') \n";

            //File.WriteAllText("log.txt", sql);
            using StreamWriter openfile = new ("log.txt",append : true);

            openfile.WriteLine(sql);

        }
    }

}