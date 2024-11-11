using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Implementations
{
    public class TastingRepository : ITastingRepository
    {
        private readonly WineContext _context;
        public TastingRepository(WineContext context)
        {
            _context = context;
        }
        public IEnumerable<Tasting> GetAllTastings()
        {
            return _context.Tastings.Include(t => t.Wines).Where(t => t.Date > DateTime.Now).ToList();
        }


        public int AddTasting(Tasting tasting)
        {
            _context.Tastings.Add(tasting);
            _context.SaveChanges();
            return tasting.Id;
        }
        public void UpdateGuestList(int id,  List<string> guests)
        {

            Tasting? tastingToUpdate = _context.Tastings.SingleOrDefault(w => w.Id == id);
            if (tastingToUpdate == null)
            {
                throw new Exception("Tasting not found");
            }
            else
            {
                tastingToUpdate.Guests.AddRange(guests);
                _context.SaveChanges();
            }
        }

    }
}
