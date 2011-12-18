using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MagicaXNAClient
{
    class Background : GraphicObject
    {
        internal override void Init(Texture2D texture)
        {
            this.texture = texture;
            screenRect = new Rectangle(0, 0, Graphic.pSingleton.getScreenWidth(), Graphic.pSingleton.getScreenHeight());
        }
        internal override void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, screenRect, Color.White);
        }
        public override float getCameraDistance()
        {
            const float farFarAway = 99999999;
            return farFarAway;
        }

        private Rectangle screenRect;
        protected Texture2D texture = null;
    }
}
