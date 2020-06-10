using System;
using System.Collections.Generic;
using System.Text;

namespace StarShipService.Helper
{
    public static class RandomGeneratorHelper
    {
        public static int RandomNumberGen(int maxRangeNumber)
        {
            Random random = new Random();
            //int maxRangeNumber = starships.Results.Count() - 1;

            int randomNumber = random.Next(0, maxRangeNumber);
            return randomNumber;
        }
    }
}
