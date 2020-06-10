using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using StarShipService.Interfaces;
using StarShipService.Models;
using Newtonsoft.Json;
using MyKindaFutureQuizBackEnd.Models;
using System.Linq;
using StarShipService.Helper;
using Microsoft.Extensions.Configuration;

namespace StarShipService
{
    public class StarShipService : IStarShipService
    {
        private static HttpClient _httpClient = new HttpClient();
        private readonly IConfiguration _configuration;

        public StarShipService(IConfiguration configuration)
        {
            _configuration = configuration;
            _httpClient.BaseAddress = new Uri(_configuration["StarShipBaseUrl"]);
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
        }
        public async Task<StarShip> GetRandomStarShip()
        {
            Result starships;

            var response = await _httpClient.GetAsync("api/starships/");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            starships = JsonConvert.DeserializeObject<Result>(content);

            if (starships.Results.Any())
            {
                int maxRangeNumber = starships.Results.Count() - 1;
                int randomNumber = RandomGeneratorHelper.RandomNumberGen(maxRangeNumber);

                return starships.Results.ToList()[randomNumber];
            }

            return null;
        }

        public async Task<StarShip> GetRandomStarShipExcludingNamesUsedBefore(List<string> namesUsedBefore)
        {
            Result starships;
            var starshipsNotUsedBefore = new List<StarShip>();

            var response = await _httpClient.GetAsync("api/starships/");
            response.EnsureSuccessStatusCode();
            string content = await response.Content.ReadAsStringAsync();
            starships = JsonConvert.DeserializeObject<Result>(content);

            if (starships.Results.Any())
            {
                foreach (var starship in starships.Results)
                {
                    if (!namesUsedBefore.Contains(starship.name))
                    {
                        starshipsNotUsedBefore.Add(starship);
                    }
                }

                int maxRangeNumber = starshipsNotUsedBefore.Count() - 1;
                int randomNumber = RandomGeneratorHelper.RandomNumberGen(maxRangeNumber);

                return starshipsNotUsedBefore[randomNumber];
            }

            return null;
        }
    }
}
