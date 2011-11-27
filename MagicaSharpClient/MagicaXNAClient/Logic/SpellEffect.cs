using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MagicaXNAClient
{
    class SpellEffect: GameObject
    {
        public SpellEffect(GameObject owner, Vector2 start, Vector2 finish, float time, Sprite effect, GameAction postAction, GameObject postObject)
            : base(effect)
        {
            this.start = start;
            this.range = finish - start;
            this.fullTime = time;
            this.elapsedTime = 0;
            this.effect = effect;
            this.postAction = postAction;
            this.postObject = postObject;
        }
        Vector2 start = Vector2.Zero,
            range = Vector2.Zero;
        float fullTime, elapsedTime;
        Sprite effect = null;
        GameAction postAction = null;
        GameObject postObject = null;
        protected GameObject owner = null;
        public override void Update(Microsoft.Xna.Framework.GameTime time, Microsoft.Xna.Framework.Input.MouseState mouseState)
        {
            elapsedTime += (float)time.ElapsedGameTime.TotalSeconds;
            if (elapsedTime >= fullTime)
            {
                postAction.Run(start + range, postObject);
                sprite.Destroy();
                Destroy();
            }
            else
            {
                Vector2 position = this.start + this.range * (1 - (fullTime - elapsedTime)/fullTime);
                sprite.Move(position);
            }
        }
    }
}
