namespace Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car;
            Tractor tractor;
            IVehicleFactory factory;
            factory = new ElectricVehicleFactory();

            car = factory.GetCar();
            tractor = factory.GetTractor();

            factory = new GasolineVehicleFactory();

            car = factory.GetCar();
            tractor = factory.GetTractor();
        }
    }
}
