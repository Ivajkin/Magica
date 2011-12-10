using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MagicaXNAClient
{
    class DoodardType
    {
        public DoodardType(string locationType, string name, int variationCount)
        {
            this.locationType = locationType;
            this.name = name;
            this.variationCount = variationCount;
        }
        public Doodard createDoodard(Vector2 position) {
            int variant = random.Next(variationCount) + 1;
            string textureType = locationType + "-" + name + "-" + (variant < 10 ? "0" : "") + variant;
            Doodard doodard = new Doodard(Graphic.pSingleton.create<Sprite>(textureType));
            doodard.Move(position);
            return doodard;
        }
        readonly string locationType;
        readonly string name;
        readonly int variationCount;
        Random random = new Random();
    }
}
