using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MagicaXNAClient
{
    class SpellEffect: GameObject
    {
        public SpellEffect(Character owner, Vector2 start, Vector2 finish, float time, string effectName, GameAction postAction, GameObject postObject)
            : base(Graphic.pSingleton.create<Sprite>(effectName), Graphic.pSingleton.create<Decal>(effectName + ".dead"))
        {
            this.start = start;
            this.range = finish - start;
            this.fullTime = time;
            this.elapsedTime = 0;
            this.postAction = postAction;
            this.postObject = postObject;
        }
        public override void Update(GameTime time, MouseState mouseState)
        {
            elapsedTime += (float)time.ElapsedGameTime.TotalSeconds;
            if (elapsedTime >= fullTime)
            {
                postAction.Run(start + range, postObject);
                this.Destroy();
                Destroy();
            }
            else
            {
                Vector2 position = this.start + this.range * (1 - (fullTime - elapsedTime)/fullTime);
                this.MoveSprites(position);
            }
        }

        internal sealed override void Damage(Character caster, Damage damage, uint amount)
        {
        }

        Vector2 start = Vector2.Zero,
            range = Vector2.Zero;
        float fullTime, elapsedTime;
        GameAction postAction = null;
        GameObject postObject = null;
        protected GameObject owner = null;
    }
}
