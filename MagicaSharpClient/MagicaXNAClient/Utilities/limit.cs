using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicaXNAClient.Utilities
{
    struct limit
    {
        public limit(int min, int max)
        {
            this.max = max;
            this.min = min;
        }
        public readonly int max, min;
        public int generate()
        {
            return random.Next(max - min) + min;
        }
        private static Random random = new Random();
    }
}
