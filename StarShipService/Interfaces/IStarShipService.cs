using StarShipService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarShipService.Interfaces
{
    public interface IStarShipService
    {
        Task<StarShip> GetRandomStarShip();
        Task<StarShip> GetRandomStarShipExcludingNamesUsedBefore(List<string> namesUsedBefore);
    }
}
