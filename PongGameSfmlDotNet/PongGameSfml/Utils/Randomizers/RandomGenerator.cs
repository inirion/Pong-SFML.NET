using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGameSfml.Utils.Randomizers
{
    class RandomGenerator : IRandomizer
    {
        private readonly Random _random;
        public RandomGenerator(Random seed = null)
        {
            this._random = seed ?? new Random();
        }
        public int Next(int lowerBoundry, int upperBoundry)
        {
            return _random.Next(lowerBoundry, upperBoundry);
        }
    }
}
