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
        /// <summary>
        /// Создаёт графический объект.
        /// </summary>
        /// <param name="url">Строковой идентификатор ресурса (например название картинки).</param>
        /// <returns>Созданный графический объект.</returns>
        public T create<T>(string url) where T : GraphicObject, new()
        {
            Texture2D texture = contentManager.Load<Texture2D>(url);
            var sprite = new T();
            sprite.Init(texture);
            graphicObjects.Add(sprite);
            return sprite;
        }

        public void Draw(GameTime time)
        {
            graphicObjects.Sort(GraphicObject.closerToCamera);

            List<GraphicObject> destroySpriteList = new List<GraphicObject>();
            device.Clear(Color.White);
            spriteBatch.Begin();
            foreach (var sprite in graphicObjects)
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
                graphicObjects.Remove(sprite);
            }
        }
        public int getScreenWidth() {
            return device.Viewport.Width;
        }
        public int getScreenHeight()
        {
            return device.Viewport.Height;
        }

        private GraphicsDevice device = null;
        private SpriteBatch spriteBatch = null;
        private ContentManager contentManager = null;
        private List<GraphicObject> graphicObjects = new List<GraphicObject>();
    }
}
