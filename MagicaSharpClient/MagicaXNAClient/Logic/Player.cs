using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MagicaXNAClient
{
    class Player: GameObject
    {
        public Player(Sprite sprite, ControlType type, Logic gameLogic, Location location) : base(sprite)
        {
            this.type = type;
            this.location = location;

            frostbolt = new FrostboltAbility();

            position = new Vector2(Graphic.pSingleton.getScreenWidth() * 0.5f, Graphic.pSingleton.getScreenHeight() * 0.5f);
        }
        override public void Update(GameTime time, MouseState mouseState)
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
            sprite.Move(position);
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                this.Move(new Vector2(mouseState.X, mouseState.Y));
            }
            else if (mouseState.RightButton == ButtonState.Pressed)
            {
                frostbolt.Cast(this, new Vector2(mouseState.X, mouseState.Y));
            }

            sprite.Move(position);
        }

        private void Move(Vector2 where)
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
        public enum ControlType
        {
            human,
            server
        }
        ControlType type;
        public ControlType controlType
        {
            get
            {
                return type;
            }
            private set
            {
            }
        }
        FrostboltAbility frostbolt = null;
        private Location location = null;
    }
}
