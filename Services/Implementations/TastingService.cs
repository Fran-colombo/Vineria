using Common.Models;
using Data.Entities;
using Data.Repositories.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class TastingService : ITastingService
    {
        private readonly ITastingRepository _repository;
        private readonly IWineRepository _wineRepository;
        public TastingService(ITastingRepository repository, IWineRepository wineRepository)
        {
            _repository = repository;
            _wineRepository = wineRepository;
        }
        public int AddTasting(TastingToCreateDto tastingDto)
        {
            if (!_repository.GetAllTastings().Any(u => u.Name == tastingDto.Name))
            {
                var newTasting = _repository.AddTasting(
                 new Tasting
                 {
                     Name = tastingDto.Name,
                     Guests = tastingDto.Guests,
                     Wines = _wineRepository.GetWinesByNames(tastingDto.WineNames),
                     Date = tastingDto.Date

                 }); 
                return newTasting;
            }
            else
            {
                throw new ArgumentException("The tasting already exists");
            }

        }

        public IEnumerable<Tasting> GetTastings()
        {
            return _repository.GetAllTastings();
        }

        public void UpdateGuestsList(int id, List<string> guests)
        {
            var tastingtoUpdate = _repository.GetAllTastings().Where(t => t.Id == id).Select(t => new { t.Id, t.Guests }).FirstOrDefault();
            if (tastingtoUpdate != null)
            {
                _repository.UpdateGuestList(id, guests);
            }
            else
            {
                throw new ArgumentException("The Guests List that you are trying to update doesn´t exist");
            }
            /*
                 {
        if (guests == null || !guests.Any())
        {
            throw new ArgumentException("Guest list cannot be empty.");
        }

        var tastingExists = _repository.GetAllTastings().Any(t => t.Id == id);
        if (!tastingExists)
        {
            throw new ArgumentException("The Guests List that you are trying to update doesn’t exist");
        }

        _repository.UpdateGuestList(id, guests);
    }*/
        }

    }
}
