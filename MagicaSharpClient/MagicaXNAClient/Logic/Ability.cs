using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MagicaXNAClient
{
    abstract class Ability<T> : Updatable where T : SpellEffect
    {
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="countdown">Время перезарядки способности (в секундах).</param>
        public Ability(float countdown)
        {
            if (countdown < 0)
            {
                throw new Exception("");
            }
            this.countdown = countdown;
        }
        /// <summary>
        /// Активировать способность.
        /// </summary>
        /// <param name="player">Кастующий персонаж.</param>
        /// <param name="where">Место, куда кастуют.</param>
        public void Cast(Player player, Vector2 where)
        {
            if (currentCountdown >= countdown)
            {
                currentCountdown -= countdown;

                Vector2 start = player.position;
                Vector2 finish = where;
                Player owner = player;
                this.spellEffect = createEffect(start, finish, owner);
            }
        }
        protected abstract T createEffect(Vector2 start, Vector2 finish, Player owner);
        private T spellEffect = null;
        /// <summary>
        /// Время перезарядки способности (максимальное, в секундах).
        /// </summary>
        private readonly float countdown;
        /// <summary>
        /// Текущий уровень заряда способности.
        /// </summary>
        private float currentCountdown = 0;

        protected override void Update(GameTime time)
        {
            currentCountdown += (float)time.ElapsedGameTime.TotalSeconds;
            if (currentCountdown > countdown)
            {
                currentCountdown = countdown;
            }
        }
    }
}
