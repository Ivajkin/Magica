using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MagicaXNAClient
{
    partial class Logic : Singleton<Logic>
    {
        internal Logic(Graphic graphic, Input input, Network network)
        {
            this.graphic = graphic;
            this.input = input;
            this.network = network;

            this.location = new Location(new LocationType("cave"));

            this.player = new Player(this.location);

            this.cursor = graphic.create<Sprite>("cursor");
        }
        public void Update(GameTime time)
        {
            List<GameObject> destroyGameObjectList = new List<GameObject>();

            var mouseState = input.getMouseState();
            var tempList = new List<GameObject>(gameObjects);
            foreach (var obj in tempList)
            {
                if (obj.isDead)
                {
                    destroyGameObjectList.Add(obj);
                }
                else
                {
                    obj.Update(time, mouseState);
                }
            }
            cursor.Move(new Vector2(mouseState.X, mouseState.Y));

            foreach (var obj in destroyGameObjectList)
            {
                gameObjects.Remove(obj);
            }

            Updatable.UpdateAll(time);
        }
        /*public void CreateGameObject(GameObject.GameObjectType objectType, GameObject owner)
        {
            if (objectType == GameObject.GameObjectType.frostbolt)
            {
                frostbolt.
                gameObjects.Add(frostbolt);
            }
        }*/
        public void registerGameObject(GameObject obj)
        {
            gameObjects.Add(obj);
        }
        private List<GameObject> gameObjects = new List<GameObject>();
        private Graphic graphic = null;
        private Input input = null;
        private Network network = null;
        private Player player = null;
        private Location location = null;
        private Sprite cursor = null;

        internal List<GameObject> getObjectsInArea(Vector2 position, float radius)
        {
            List<GameObject> areaObjects = new List<GameObject>();
            foreach (GameObject obj in gameObjects)
            {
                if((obj.position - position).LengthSquared() < radius*radius) {
                    areaObjects.Add(obj);
                }
            }
            return areaObjects;
        }
    }
}
