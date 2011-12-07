using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MagicaXNAClient
{
    abstract class GraphicObject
    {
        public GraphicObject()
        {
            isDead = false;
        }
        internal abstract void Init(Texture2D texture);
        internal abstract void Draw(GameTime time, SpriteBatch spriteBatch);

        internal void Destroy()
        {
            isDead = true;
        }
        public bool isDead { get; private set; }
    }
}
