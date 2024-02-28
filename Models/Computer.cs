namespace HelloWorld.Models
{
        public class Computer
    {
        public string? Motherboard {get; set;}
        public int CPUCores {get; set;}
        public bool HasWifi {get; set;}
        public DateTime ReleaseDate {get; set;}
        public decimal Price {get; set;}
        public string? VideoCard {get; set;}
        // public Computer(string motherboard, int cores, bool hasWiFi, DateTime releaseDate, decimal price, string videoCard)
        // {
        //     Motherboard = motherboard;
        //     CPUCores = cores;
        //     HasWifi =hasWiFi;
        //     ReleaseDate = releaseDate;
        //     Price = price;
        //     VideoCard = videoCard;
        // }

    }
}