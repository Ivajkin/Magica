using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MagicaXNAClient
{
    class Sprite
    {
        public Sprite(Texture2D texture)
        {
            isDead = false;
            this.texture = texture;
        }

        internal void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        internal void Move(Vector2 position)
        {
            this.position = position;
        }

        Texture2D texture = null;
        Vector2 position = Vector2.Zero;

        internal void Destroy()
        {
            isDead = true;
        }
        public bool isDead { get; private set; }
    }
}
