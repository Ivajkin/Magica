using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using MagicaXNAClient.Utilities;

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

                backgroundVariationCount = 2;
            }
            else
            {
                throw new Exception("LocationType не инициализирован, так как name=" + name);
            }

            this.name = name;
        }
        public void generateDoodards()
        {
            foreach (var countG in doodardCount)
            {
                var name = countG.Key;
                var lim = countG.Value;
                for (int i = 0, count = lim.generate(); i < count; ++i)
                {
                    float x = (float)random.NextDouble() * (Graphic.pSingleton.getScreenWidth() - wallMargin*2) + wallMargin;
                    float y = (float)random.NextDouble() * (Graphic.pSingleton.getScreenHeight() - wallMargin*2) + wallMargin;
                    doodardTypes[name].createDoodard(new Vector2(x, y));
                }
            }
        }
        internal void createBackground()
        {
            int variation = random.Next(backgroundVariationCount) + 1;
            background = Graphic.pSingleton.create<Background>(name + "-background-" + (variation < 10 ? "0" : "") + variation);
        }

        private Dictionary<string, DoodardType> doodardTypes = new Dictionary<string,DoodardType>();
        private Dictionary<string, limit> doodardCount = new Dictionary<string,limit>();
        private readonly int backgroundVariationCount;
        private readonly string name;
        private Sprite background = null;

        /// <summary>
        /// Расстояние от края экрана.
        /// </summary>
        public const float wallMargin = 175;

        private static Random random = new Random();
    }
}
