using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MagicaXNAClient
{
    abstract class Character : GameObject
    {
        public Character(Sprite sprite, Location location)
            : base(sprite)
        {
            this.location = location;

            position = new Vector2(Graphic.pSingleton.getScreenWidth() * 0.5f, Graphic.pSingleton.getScreenHeight() * 0.5f);
        }
        sealed override public void Update(GameTime time, MouseState mouseState)
        {
            if (isMoving)
            {
                var range = moveOrderAim - position;
                if (velocity != Vector2.Zero)
                {
                    position += velocity * (float)time.ElapsedGameTime.TotalSeconds;
                }
                if (range.LengthSquared() < minMoveRangeSquared)
                {
                    isMoving = false;
                    velocity = Vector2.Zero;
                    moveOrderAim = position;
                }
                range.Normalize();
                velocity = linearVelocity * range;
            }
            InputReaction(time, mouseState);

            sprite.Move(position);
        }
        protected abstract void InputReaction(GameTime time, MouseState mouseState);

        protected void Move(Vector2 where)
        {
            moveOrderAim = location.nearestFreePoint(where);

            var range = moveOrderAim - position;
            if (range.LengthSquared() > minMoveRangeSquared)
            {
                isMoving = true;
            }
        }
        //private List<Vector2> MOAOrder = ;
        private Vector2 moveOrderAim = Vector2.Zero;
        private bool isMoving = false;
        const double minMoveRangeSquared = 100;
        Vector2 velocity = Vector2.Zero;
        /// <summary>
        /// Per second.
        /// </summary>
        const float linearVelocity = 100;
        protected Location location = null;
    }
}
