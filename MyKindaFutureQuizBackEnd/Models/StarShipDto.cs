using System.Collections.Generic;

namespace MyKindaFutureQuizBackEnd.Models
{
    public class StarShipDto
    {
        public string name { get; set; }
        public string Starship_class { get; set; }
        public int Max_atmosphering_speed { get; set; }
        public int Cost_in_credits { get; set; }
        public int Passengers { get; set; }
        public List<string> Films { get; set; } = new List<string>();
        public int TotalFilms => Films.Count;
    }
}
