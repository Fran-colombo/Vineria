using Common.Models;
using Data.Entities;
using Data.Repositories.Implementations;
using Data.Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class WineService : IWineService
    {
        private readonly IWineRepository _repository;
        public WineService(IWineRepository repository)
        {
            _repository = repository;
        }



        public int AddWine(WineForCreationDto wineDTO)
        {
            if (!_repository.GetAllWines().Any(e => e.Name == wineDTO.Name))
            {
                var newWine = _repository.AddWine(
                new Wine
                {
                    Name = wineDTO.Name,
                    Variety = wineDTO.Variety,
                    Year = wineDTO.Year,
                    Region = wineDTO.Region,
                    Stock = wineDTO.Stock,
                    CreatedAt = DateTime.UtcNow
                });
                return newWine;
            }
            else
            {
                throw new ArgumentException("The Wine already exists.");
            }

        }
        public void UpdateWineById(int id, int stock)
        {
            if(stock < 0)
            {
                throw new ArgumentException("You can´have negative stock. C´mon you are better than this");
            }

            var wineToUpdate = _repository.GetWineById(id);
            if (wineToUpdate == null)
            
            {
                throw new ArgumentException("Wine not found");
            }

            _repository.UpdateStockById(id, stock);

        }

        public IEnumerable<Wine> GetAllWines()
        {
            return _repository.GetAllWines();
        }
        public IEnumerable<Wine>? GetStockedWines()
        {
            return _repository.GetStockedWines();
        }
        public List<Wine>? GetWineByVarirety(string variety)
        {
            return _repository.GetWinesByVariety(variety);
        }
        public Wine? GetWineById(int Id)
        {
            return _repository.GetWineById(Id);
        }

    }
}
