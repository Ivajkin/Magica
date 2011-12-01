using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MagicaXNAClient
{
    class LocationType
    {
        public LocationType(string name) {
            if (name == "cave")
            {
                doodardTypes["mushroom"] = new DoodardType(name, "mushroom", 2);
                doodardCount["mushroom"] = new limit(10, 15);

                doodardTypes["rock"] = new DoodardType(name, "rock", 2);
                doodardCount["rock"] = new limit(7, 9);
            }
            else
            {
                throw new Exception("LocationType не инициализирован, так как name=" + name);
            }

            generateDoodards();
        }
        public void generateDoodards()
        {
            foreach (var countG in doodardCount)
            {
                var name = countG.Key;
                var lim = countG.Value;
                for (int i = 0, count = lim.generate(); i < count; ++i)
                {
                    float x = (float)random.NextDouble() * 800;
                    float y = (float)random.NextDouble() * 600;
                    doodardTypes[name].createDoodard(new Vector2(x, y));
                }
            }
        }
        private Dictionary<string, DoodardType> doodardTypes = new Dictionary<string,DoodardType>();
        private Dictionary<string, limit> doodardCount = new Dictionary<string,limit>();
        private struct limit
        {
            public limit(int min, int max)
            {
                this.max = max;
                this.min = min;
            }
            public readonly int max, min;
            public int generate() {
                return random.Next(max - min) + min;
            }
            private static Random random = new Random();
        }
        private static Random random = new Random();
    }
}
