using Common.Models;
using Data.Entities;

namespace Services.Interfaces
{
    public interface IWineService
    {
        int AddWine(WineForCreationDto wineDTO);
        IEnumerable<Wine> GetAllWines();
        IEnumerable<Wine>? GetStockedWines();
        Wine? GetWineById(int Id);
        List<Wine>? GetWineByVarirety(string variety);
        void UpdateWineById(int id, int stock);
    }
}