using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MagicaXNAClient
{
    abstract class Ability<T> where T : SpellEffect
    {
        public void Cast(Player player, Vector2 where)
        {
            Vector2 start = player.position;
            Vector2 finish = where;
            Player owner = player;
            this.spellEffect = createEffect(start, finish, owner);
        }
        protected abstract T createEffect(Vector2 start, Vector2 finish, Player owner);
        protected T spellEffect = null;
    }
}
