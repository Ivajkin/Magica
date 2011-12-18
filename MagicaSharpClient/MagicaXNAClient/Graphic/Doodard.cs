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
            this.MoveSprites(position);
        }

        internal override void Damage(Character caster, Damage damageType, uint damageAmount)
        {
            health -= (int)damageAmount;
            if (health <= 0)
            {
                this.Destroy();
            }
        }

        int health = maxHealth;
        const int maxHealth = 20;
    }
}
