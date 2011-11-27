using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MagicaXNAClient
{
    class FrostboltAbility: Ability<FrostboltSpellEffect>
    {
        protected override FrostboltSpellEffect createEffect(Vector2 start, Vector2 finish, Player owner)
        {
            return new FrostboltSpellEffect(start, finish, Graphic.pSingleton.createSprite("frostbolt"), owner);
        }
    }
}
