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
            boundary = new Vector2(texture.Width, texture.Height);
        }

        internal void Draw(GameTime time, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position - boundary * 0.5f, Color.White);
        }

        internal void Move(Vector2 position)
        {
            this.position = position;
        }

        private Texture2D texture = null;
        private Vector2 position = Vector2.Zero;
        private Vector2 boundary = Vector2.Zero;

        internal void Destroy()
        {
            isDead = true;
        }
        public bool isDead { get; private set; }
    }
}
