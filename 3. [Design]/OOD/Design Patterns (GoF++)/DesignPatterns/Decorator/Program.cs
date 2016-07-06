using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var coolAmbulance = new AmbulanceCar(new Mercedes());
            coolAmbulance.Go();

            Console.ReadLine();
        }
    }
}
