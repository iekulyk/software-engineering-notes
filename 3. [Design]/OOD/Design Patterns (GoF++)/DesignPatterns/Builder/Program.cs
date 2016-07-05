using System;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            var downhillBuilder = new DownhillBikeBuilder();
            var bikeShop = new BikeShop();

            bikeShop.SetBikeBuilder(downhillBuilder);
            bikeShop.ConstructBike();

            Bike bike = bikeShop.GetBike();

            Console.Write(bike.ToString());
            Console.ReadLine();
        }
    }
}
