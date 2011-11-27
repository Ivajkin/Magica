using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MagicaXNAClient
{
    class FrostboltSpellEffect : SpellEffect
    {
        public FrostboltSpellEffect(Vector2 start, Vector2 finish, Sprite sprite, GameObject owner)
            : base(owner, start, finish, (finish - start).Length() / linearVelocity, sprite, new FrostboltGameAction(), null)
        {
            this.owner = owner;
        }
        /// <summary>
        /// Per second.
        /// </summary>
        const float linearVelocity = 320;
    }
}
