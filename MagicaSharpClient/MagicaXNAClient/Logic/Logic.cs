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
            this.cursor = graphic.createSprite("cursor");
            this.location = new Location(new LocationType("cave"));
            this.player = new Player(graphic.createSprite("inquisitor"), Player.ControlType.human, this);
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
        List<GameObject> gameObjects = new List<GameObject>();
        Graphic graphic = null;
        Input input = null;
        Network network = null;
        Player player = null;
        Location location = null;
        Sprite cursor = null;

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
