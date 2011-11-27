using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MagicaXNAClient
{
    abstract class AreaGameAction : GameAction
    {
        public AreaGameAction(float radius) {
            this.radius = radius;
        }
        sealed internal override void Run(Vector2 position, GameObject postObject)
        {
            List<GameObject> objects = Logic.pSingleton.getObjectsInArea(position, radius);
            foreach (GameObject obj in objects)
            {
                postEffect(obj);
            }
        }
        private float radius;
        /// <summary>
        /// Событие, происходящее со всеми объектами в пределах определённого радиуса вокруг определённой точки.
        /// </summary>
        public abstract void postEffect(GameObject obj);
    }
}