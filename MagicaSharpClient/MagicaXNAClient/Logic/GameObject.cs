using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MagicaXNAClient
{
    abstract class GameObject
    {
        public GameObject(Sprite sprite)
        {
            Init(sprite, sprite);
        }
        public GameObject(Sprite sprite, Sprite spriteDead)
        {
            Init(sprite, spriteDead);
            this.spriteDead.Hide(true);
        }
        public GameObject(Sprite sprite, Sprite spriteDead, float glowSize)
        {
            Init(sprite, spriteDead);
            this.spriteDead.Hide(true);
        }
        private void Init(Sprite sprite, Sprite spriteDead)
        {
            isDead = false;
            this.sprite = sprite;
            this.spriteDead = spriteDead;
            Logic.pSingleton.registerGameObject(this);
        }
        protected void MoveSprites(Vector2 position)
        {
            sprite.Move(position);
            spriteDead.Move(position);
        }
        abstract public void Update(GameTime time, MouseState mouseState);
        /// <summary>
        /// Нанести повреждение персонажу.
        /// </summary>
        /// <param name="caster">Кто наносит.</param>
        /// <param name="damageType">Тип повреждения.</param>
        /// <param name="damageAmount">Количество повреждения (очков жизни).</param>
        internal abstract void Damage(Character caster, Damage damageType, uint damageAmount);

        internal void Destroy()
        {
            isDead = true;
            // Прячем его спрайт и делаем видимым спрайт смерти.
            sprite.Hide(true);
            spriteDead.Hide(false);
        }
        public bool isDead { get; private set; }

        //abstract public void OnClick(MouseState mouseState);
        private Sprite sprite = null,
                         spriteDead = null;

        public enum GameObjectType
        {
            player
        }
        public Vector2 position { get; protected set; }
    }
}
