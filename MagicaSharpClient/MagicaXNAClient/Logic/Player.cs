using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MagicaXNAClient
{
    class Player: Character
    {
        public Player(Location location)
            : base(Graphic.pSingleton.create<Sprite>("inquisitor"), location)
        {
            frostbolt = new FrostboltAbility();

            //position = new Vector2(Graphic.pSingleton.getScreenWidth() * 0.5f, Graphic.pSingleton.getScreenHeight() * 0.5f);
        }
        protected override void InputReaction(GameTime time, MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                this.Move(new Vector2(mouseState.X, mouseState.Y));
            }
            else if (mouseState.RightButton == ButtonState.Pressed)
            {
                frostbolt.Cast(this, new Vector2(mouseState.X, mouseState.Y));
            }
        }

        FrostboltAbility frostbolt = null;
    }
}
