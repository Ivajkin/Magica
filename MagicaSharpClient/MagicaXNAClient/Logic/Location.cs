using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MagicaXNAClient
{
    class Location
    {
        public Location(LocationType type)
        {
            type.createBackground();
            type.generateDoodards();

            this.type = type;
        }
        /// <summary>
        /// Ближайшая точка к данной, на которой можно стоять.
        /// </summary>
        /// <returns>Новая, сдвинутая если была за пределами точка.</returns>
        public Vector2 nearestFreePoint(Vector2 original)
        {
            if (original.X < LocationType.wallMargin)
            {
                original.X = LocationType.wallMargin;
            }
            else if (original.X > Graphic.pSingleton.getScreenWidth() - LocationType.wallMargin)
            {
                original.X = Graphic.pSingleton.getScreenWidth() - LocationType.wallMargin;
            }

            if (original.Y < LocationType.wallMargin)
            {
                original.Y = LocationType.wallMargin;
            }
            else if (original.Y > Graphic.pSingleton.getScreenHeight() - LocationType.wallMargin)
            {
                original.Y = Graphic.pSingleton.getScreenHeight() - LocationType.wallMargin;
            }

            return original;
        }
        private List<Doodard> doodards = new List<Doodard>();
        private LocationType type = null;
    }
}
