using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface ITastingRepository
    {
        int AddTasting(Tasting tasting);
        IEnumerable<Tasting> GetAllTastings();
        void UpdateGuestList(int id, List<string> guests);
    }
}