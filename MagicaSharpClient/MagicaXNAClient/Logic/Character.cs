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
        public Character(CharacterType type, Fraction fraction, Location location)
            : base(type.sprite, type.spriteDead, glowSize)
        {
            this.fraction = fraction;
            this.location = location;

            position = new Vector2(Graphic.pSingleton.getScreenWidth() * 0.5f, Graphic.pSingleton.getScreenHeight() * 0.5f);

            this.maxHealth = type.maxHealth;
            this.health = this.maxHealth;
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

            this.MoveSprites(position);
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
        /// <summary>
        /// Нанести повреждение персонажу.
        /// </summary>
        /// <param name="caster">Кто наносит.</param>
        /// <param name="damageType">Тип повреждения.</param>
        /// <param name="damageAmount">Количество повреждения (очков жизни).</param>
        internal override void Damage(Character caster, Damage damageType, uint damageAmount)
        {
            health -= (int)damageAmount;
            if (this.health <= 0)
            {
                this.Destroy();
            }
        }

        int health;
        readonly int maxHealth;

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
        protected Fraction fraction;
        private const float glowSize = 2048;
    }
}
