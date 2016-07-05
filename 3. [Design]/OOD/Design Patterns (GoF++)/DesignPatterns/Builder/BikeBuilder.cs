namespace Builder
{
    public abstract class BikeBuilder
    {
        protected Bike Bike { get; private set; }

        public void CreateNewBike()
        {
            Bike = new Bike();
        }

        public Bike GetBike()
        {
            return Bike;
        }

        public abstract void SetGantry();
        public abstract void SetRim();
        public abstract void SetTires();
        public abstract void SetDerailleur();
        public abstract void SetBreaks();

    }
}