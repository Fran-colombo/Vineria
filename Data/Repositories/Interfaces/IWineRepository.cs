using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface IWineRepository
    {
        int AddWine(Wine wine);
        ICollection<Wine> GetAllWines();
        ICollection<Wine>? GetStockedWines();
        Wine? GetWineById(int Id);
        List<Wine> GetWinesByNames(List<string> names);
        List<Wine>? GetWinesByVariety(string variety);
        void UpdateStockById(int Id, int Stock);
    }
}