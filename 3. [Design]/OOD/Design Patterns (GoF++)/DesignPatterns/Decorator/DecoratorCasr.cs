using System;

namespace Decorator
{
    class DecoratorCasr : Car
    {
        protected Car DecoratedCar { get; set; }

        public DecoratorCasr(Car decoratedCar)
        {
            DecoratedCar = decoratedCar;
        }

        public override void Go()
        {
            DecoratedCar.Go();
        }
    }

    class AmbulanceCar : DecoratorCasr
    {
        public AmbulanceCar(Car decoratedCar) : base(decoratedCar)
        {
        }

        public override void Go()
        {
            base.Go();
            Console.WriteLine("... beeep-beeee-beeeeeeeep ...");
        }
    }
}