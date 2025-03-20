namespace BookingTourTravelBuzz.Models.Guides
{
    public interface IGuideRepostory
    {
        IEnumerable<Guide> GetAll();
        Guide? GetById(int id);
        void Create(Guide guide);
        void Edit(Guide guide);
        void Delete(int id);
    }
}
