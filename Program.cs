using System.Data;
using Dapper;
using HelloWorld.Data;
using HelloWorld.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace HelloWorld
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
            DataContextDapper dapper = new DataContextDapper(config);
            DataContextEF entityFrameWork = new DataContextEF(config);

            string sqlCommand =  "SELECT GETDATE()";
            DateTime  rightNow = dapper.LoadDateSingle<DateTime>(sqlCommand);
            
            Computer myComp = new Computer()
            {
                Motherboard ="Inteli7",
                CPUCores = 12,
                HasWifi = true,
                ReleaseDate = DateTime.Now,
                Price = 99.99m,
                VideoCard = "Nvidia OrSOMT"

            };

            entityFrameWork.Add(myComp);
            entityFrameWork.SaveChanges();

            Console.WriteLine(rightNow);
            // string sql = @"INSERT INTO TutorialAppSchema.Computer (
            //     Motherboard,
            //     CPUCores,
            //     HasWifi,
            //     ReleaseDate,
            //     Price,
            //     VideoCard
            //     ) VALUES ('" + myComp.Motherboard 
            //          + "','" + myComp.CPUCores
            //          + "','" + myComp.HasWifi
            //          + "','" + myComp.ReleaseDate
            //          + "','" + myComp.Price
            //          + "','" + myComp.VideoCard + "')";

            // Console.WriteLine(sql);

            // int result = dbConnection.Execute(sql);

            // Console.WriteLine(result);
            string sqlSelect = @"SELECT 
                             Motherboard,
                             CPUCores,
                             HasWifi,
                             ReleaseDate,
                             Price,
                             VideoCard 
                             FROM TutorialAppSchema.Computer";

            IEnumerable<Computer> computers = dapper.LoadData<Computer>(sqlSelect);
            
            IEnumerable<Computer>? computersEF = entityFrameWork.Computer?.ToList<Computer>();

            if (computersEF == null) return;
            foreach (Computer computer in computersEF)
            {
                Console.WriteLine(computer.Motherboard 
                     + "','" + computer.CPUCores
                     + "','" + computer.HasWifi
                     + "','" + computer.ReleaseDate
                     + "','" + computer.Price
                     + "','" + computer.VideoCard + "')");
            }
        }
    }

}