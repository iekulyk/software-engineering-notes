namespace Builder
{
    public class BikeShop
    {
        private BikeBuilder _bikeBuilder;

        public void SetBikeBuilder(BikeBuilder builder)
        {
            _bikeBuilder = builder;
        }

        public Bike GetBike()
        {
            return _bikeBuilder.GetBike();
        }

        public void ConstructBike()
        {
            _bikeBuilder.CreateNewBike();
            _bikeBuilder.SetBreaks();
            _bikeBuilder.SetDerailleur();
            _bikeBuilder.SetGantry();
            _bikeBuilder.SetRim();
            _bikeBuilder.SetTires();
        }
    }
}
