namespace Factory
{
    public interface IVehicleFactory
    {
        Car GetCar();
        Tractor GetTractor();
    }
}