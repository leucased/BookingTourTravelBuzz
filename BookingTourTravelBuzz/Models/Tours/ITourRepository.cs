namespace BookingTourTravelBuzz.Models.Tours
{
    public interface ITourRepository
    {
        IEnumerable<Tour> GetAllDomesticTours();
        IEnumerable<Tour> GetAllInternationalTours();
        Tour? GetTourById(int id);

    }
}
