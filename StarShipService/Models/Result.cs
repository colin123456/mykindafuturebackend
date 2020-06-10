using StarShipService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyKindaFutureQuizBackEnd.Models
{
    public class Result
    {
        public IEnumerable<StarShip> Results { get; set; } = new List<StarShip>();
    }
}
