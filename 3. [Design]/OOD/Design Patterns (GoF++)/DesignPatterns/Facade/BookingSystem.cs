namespace Facade
{
    internal class BookingSystem
    {
        private readonly CarBooking _carBooking = new CarBooking();
        private readonly PlaneBooking _planeBooking = new PlaneBooking();
        private readonly HotelBooking _hotelBooking = new HotelBooking();

        public decimal BookTrip(string startingPoint, string destinationPoit)
        {
            var carRentalPrice = _carBooking.RentACar(destinationPoit);
            var planeFlightPrice = _planeBooking.BookPlane(startingPoint, destinationPoit);
            var hotellPrice = _hotelBooking.BookHotel(destinationPoit);

            return carRentalPrice + planeFlightPrice + hotellPrice;
        }
    }
}