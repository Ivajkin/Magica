using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MagicaXNAClient
{
    class Graphic: Singleton<Graphic>
    {
        public Graphic(GraphicsDevice device, ContentManager contentManager)
        {
            this.device = device;
            this.contentManager = contentManager;
            this.spriteBatch = new SpriteBatch(device);
        }
        public Sprite createSprite(string url)
        {
            Texture2D texture = contentManager.Load<Texture2D>(url);
            var sprite = new Sprite(texture);
            sprites.Add(sprite);
            return sprite;
        }
        public void Draw(GameTime time)
        {
            List<Sprite> destroySpriteList = new List<Sprite>();
            device.Clear(Color.White);
            spriteBatch.Begin();
            foreach (var sprite in sprites)
            {
                if (sprite.isDead)
                {
                    destroySpriteList.Add(sprite);
                }
                else
                {
                    sprite.Draw(time, spriteBatch);
                }
            }
            spriteBatch.End();

            foreach (var sprite in destroySpriteList)
            {
                sprites.Remove(sprite);
            }
        }
        private GraphicsDevice device = null;
        private SpriteBatch spriteBatch = null;
        private ContentManager contentManager = null;
        List<Sprite> sprites = new List<Sprite>();
    }
}
