using Common.Models;
using Data.Entities;

namespace Services.Interfaces
{
    public interface ITastingService
    {
        int AddTasting(TastingToCreateDto tastingDto);
        IEnumerable<Tasting> GetTastings();
        void UpdateGuestsList(int id, List<string> guests);
    }
}