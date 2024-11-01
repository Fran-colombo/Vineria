using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Wine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;


        public string Variety { get; set; } = string.Empty;

        [Range(0, 2024, ErrorMessage = "The vintage year must be between 0 and this year")]
        public int Year { get; set; }

        
        public string Region { get; set; } = string.Empty;


        [Range(0, int.MaxValue, ErrorMessage = "You can´t add a stock slower than 0")]
        public int Stock { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public void AddStock(int amount)
        {
            if (amount <= 0) throw new ArgumentException("La cantidad a añadir debe ser mayor a 0.");
            Stock += amount;
        }


        public void RemoveStock(int amount)
        {
            if (amount <= 0) throw new ArgumentException("La cantidad a reducir debe ser mayor a 0.");
            if (Stock - amount < 0) throw new InvalidOperationException("No hay suficiente stock disponible.");
            Stock -= amount;
        }
    }
}
 

