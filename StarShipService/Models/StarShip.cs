using System.Collections.Generic;

namespace StarShipService.Models
{
    public class StarShip
    {
        public string name { get; set; }
        public string Starship_class { get; set; }
        public string Max_atmosphering_speed { get; set; }
        public string Cost_in_credits { get; set; }
        public string Passengers { get; set; }
        public List<string> Films { get; set; } = new List<string>();
        public int TotalFilms => Films.Count;
    }
}
