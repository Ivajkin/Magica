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
            isDead = false;

            this.sprite = sprite;

            Logic.pSingleton.registerGameObject(this);
        }
        abstract public void Update(GameTime time, MouseState mouseState);
        //abstract public void OnClick(MouseState mouseState);
        protected Sprite sprite = null;
        public enum GameObjectType
        {
            player
        }
        public Vector2 position { get; protected set; }

        internal void Destroy()
        {
            isDead = true;
        }
        public bool isDead { get; private set; }
    }
}
