namespace Factory
{
    class ElectricVehicleFactory : IVehicleFactory
    {
        public Car GetCar()
        {
            return new ElectricCar();
        }

        public Tractor GetTractor()
        {
            return new ElectricTractor();
        }
    }
}