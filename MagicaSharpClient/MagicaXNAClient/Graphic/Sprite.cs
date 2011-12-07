using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MagicaXNAClient
{
    class Sprite : GraphicObject
    {
        internal override void Init(Texture2D texture)
        {
            this.texture = texture;
            boundary = new Vector2(texture.Width, texture.Height);
        }

        internal override void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position - boundary * 0.5f, Color.White);
        }

        internal void Move(Vector2 position)
        {
            this.position = position;
        }

        protected Texture2D texture = null;
        protected Vector2 position = Vector2.Zero;
        protected Vector2 boundary = Vector2.Zero;
    }
}
