using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using MagicaXNAClient.Utilities;

namespace MagicaXNAClient
{
    class Creep : Character
    {
        public Creep(string type, Location location)
            : base(Graphic.pSingleton.create<Sprite>("creep/" + type), location)
        {
        }
        protected override void InputReaction(GameTime time, MouseState mouseState)
        {
            timeToMove -= (float)time.ElapsedGameTime.TotalSeconds;
            if (timeToMove < 0)
            {
                Vector2 randomPoint = new Vector2(
                    (float)random.NextDouble() * Graphic.pSingleton.getScreenWidth(),
                    (float)random.NextDouble() * Graphic.pSingleton.getScreenHeight()
                );
                this.Move(location.nearestFreePoint(randomPoint));

                timeToMove += (float)random.NextDouble() + 1;
            }
        }
        private float timeToMove = 0;
        private static Random random = new Random();
    }
}
