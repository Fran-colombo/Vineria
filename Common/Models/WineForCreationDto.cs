using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class WineForCreationDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Variety { get; set; } = string.Empty;

        public int Year { get; set; }
        public string Region { get; set; } = string.Empty;
        [Required]
        public int Stock { get; set; }
    }
}
