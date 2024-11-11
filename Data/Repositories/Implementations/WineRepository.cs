using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class WineRepository : IWineRepository
    {
        private readonly WineContext _context;
        public WineRepository(WineContext context)
        {
            _context = context;
        }


        public ICollection<Wine> GetAllWines()
        {
            return _context.Wines.ToList();
        }
        public ICollection<Wine>? GetStockedWines()
        {
            return _context.Wines.Where(w => w.Stock > 0).ToList();
        }


        public List<Wine>? GetWinesByVariety(string variety)
        {
            return _context.Wines.Where(w => w.Variety == variety).ToList();
        }
        public Wine? GetWineById(int Id)
        {
            var wine = _context.Wines.FirstOrDefault(w => w.Id == Id);
            if (wine == null) {
                throw new Exception("Wine not found");
            }
            return wine;
        }
        public List<Wine> GetWinesByNames(List<string> names)
        {
            return _context.Wines.Where(w => names.Contains(w.Name)).ToList();
        }

        public int AddWine(Wine wine)
        {
            _context.Wines.Add(wine);
            _context.SaveChanges();
            return wine.Id;
        }

        public void UpdateStockById(int Id, int Stock)
        {

            var wineToUpdate = GetWineById(Id);
            wineToUpdate.Stock = Stock;
            _context.SaveChanges();
            
        }

    }
}
