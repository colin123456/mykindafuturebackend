using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyKindaFutureQuizBackEnd.Models
{
    public class ResultDto
    {
        public IEnumerable<StarShipDto> Results { get; set; } = new List<StarShipDto>();
    }
}
