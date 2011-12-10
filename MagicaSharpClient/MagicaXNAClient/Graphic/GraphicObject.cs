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

        public abstract float getCameraDistance();

        static public int closerToCamera(GraphicObject obj1, GraphicObject obj2)
        {
            if (obj1.getCameraDistance() < obj2.getCameraDistance())
            {
                return 1;
            }
            else if (obj1.getCameraDistance() > obj2.getCameraDistance())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
