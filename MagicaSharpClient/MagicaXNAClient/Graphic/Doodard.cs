using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MagicaXNAClient
{
    class Doodard : GameObject
    {
        public Doodard(Sprite sprite) : base(sprite)
        {
        }
        public override void Update(GameTime time, MouseState mouseState)
        {
        }

        internal void Move(Vector2 position)
        {
            this.position = position;
            sprite.Move(position);
        }
    }
}
