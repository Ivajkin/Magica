using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MagicaXNAClient
{
    abstract class Item : GameObject
    {
        Item(string name)
            : base(Graphic.pSingleton.create<Sprite>("items/" + name))
        {
        }
        public sealed override void Update(GameTime time, MouseState mouseState)
        {
            ItemUpdate(time);
        }
        protected abstract void ItemUpdate(GameTime time);
        protected abstract void TakeAction(Character taker);
        private const float takeRadius = 10;
    }
}
