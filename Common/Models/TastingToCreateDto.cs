

using Data.Entities;

namespace Common.Models
{
    public class TastingToCreateDto
    {

        public DateTime Date { get; set; }
        public string? Name { get; set; }
        public List<string> WineNames { get; set; } = new List<string>();
        public List<string>? Guests { get; set; }
    }
}
