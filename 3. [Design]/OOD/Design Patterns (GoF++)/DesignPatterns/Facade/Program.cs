using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var bookinSystem = new BookingSystem();

            var tripPrice = bookinSystem.BookTrip("Ibiza", "Somali");
            Console.WriteLine(tripPrice);

            Console.ReadLine();
        }
    }
}
