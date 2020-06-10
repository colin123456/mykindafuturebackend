using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Application.interfaces;
using Domain.Starships;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyKindaFutureQuizBackEnd.Models;
using Newtonsoft.Json;
using StarShipService.Interfaces;

namespace MyKindaFutureQuizBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StarShipController : ControllerBase
    {
        private const int MaxRangeReset = 9;

        private readonly IStarShipService _starShipService;
        private readonly IUnitOfWork _unitOfWork;
        public StarShipController(IStarShipService starShipService,
                                    IUnitOfWork unitOfWork)
        {
            _starShipService = starShipService;
            _unitOfWork = unitOfWork;

        }
        // GET: api/StarShip
        [HttpGet]
        public async Task<ActionResult<StarShipDto>> GetStarShipsAsync()
        {
            try
            {
                var starshipsAlreadyUsedEntities = _unitOfWork.Starships.GetAll();
                
                if (starshipsAlreadyUsedEntities.Count() > MaxRangeReset)
                {
                    ResetGame(starshipsAlreadyUsedEntities);
                }
                
                var namesUsedBefore = starshipsAlreadyUsedEntities.Select(n => n.name).ToList();
                var starShipModel = await _starShipService.GetRandomStarShipExcludingNamesUsedBefore(namesUsedBefore);
                
                if (starShipModel != null)
                {
                    var starShipEntity = new StarShip()
                    {
                        Id = Guid.NewGuid(),
                        name = starShipModel.name,
                        Starship_class = starShipModel.Starship_class,
                        Max_atmosphering_speed = ConvertStringToNumber(starShipModel.Max_atmosphering_speed),
                        Cost_in_credits = ConvertStringToNumber(starShipModel.Cost_in_credits),
                        Passengers = ConvertStringToNumber(starShipModel.Passengers),
                        TotalFilms = starShipModel.Films.Count
                    };
                    
                    _unitOfWork.Starships.Add(starShipEntity);
                    _unitOfWork.Save();

                    var starShipDto = new StarShipDto()
                    {
                        name = starShipModel.name,
                        Starship_class = starShipModel.Starship_class,
                        Max_atmosphering_speed = ConvertStringToNumber(starShipModel.Max_atmosphering_speed),
                        Cost_in_credits = ConvertStringToNumber(starShipModel.Cost_in_credits),
                        Passengers = ConvertStringToNumber(starShipModel.Passengers),
                        Films = starShipModel.Films
                    };

                    return Ok(starShipDto);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        private int ConvertStringToNumber(string stringToConvert)
        {
            bool result;
            int number = 0;
            result = int.TryParse(stringToConvert, out number);

            if (result)
            {
                return number;
            }
            return number;
        }

        private void ResetGame(IEnumerable<StarShip> starshipEntities)
        {
            _unitOfWork.Starships.RemoveRange(starshipEntities);
            _unitOfWork.Save();
        }
    }
}
