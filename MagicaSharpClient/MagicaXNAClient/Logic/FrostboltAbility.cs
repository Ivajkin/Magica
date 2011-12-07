using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MagicaXNAClient
{
    class FrostboltAbility: Ability<FrostboltSpellEffect>
    {
        public FrostboltAbility() : base(0.5f)
        {
        }
        protected override FrostboltSpellEffect createEffect(Vector2 start, Vector2 finish, Player owner)
        {
            return new FrostboltSpellEffect(start, finish, Graphic.pSingleton.create<Sprite>("frostbolt"), owner);
        }
    }
}
