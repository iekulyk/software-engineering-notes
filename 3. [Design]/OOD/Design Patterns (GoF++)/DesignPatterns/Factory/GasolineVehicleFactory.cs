namespace Factory
{
    class GasolineVehicleFactory : IVehicleFactory
    {
        public Car GetCar()
        {
            return new GasolineCar();
        }

        public Tractor GetTractor()
        {
            return new Tractor();
        }
    }
}