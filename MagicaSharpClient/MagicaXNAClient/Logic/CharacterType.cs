using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicaXNAClient
{
    class CharacterType
    {
        public CharacterType(string name)
        {
            sprite = Graphic.pSingleton.create<Sprite>("chars/" + name);
            spriteDead = Graphic.pSingleton.create<Sprite>("chars/" + name + ".dead");

            if(name == "mexico") {
                maxHealth = 35;
            }
            else if (name == "inquisitor")
            {
                maxHealth = 50;
            }
            else
            {
                throw new Exception("CharacterType не инициализирован, так как name=" + name);
            }
        }

        internal Sprite sprite
        {
            get;
            private set;
        }
        internal Sprite spriteDead
        {
            get;
            private set;
        }
        internal int maxHealth
        {
            get;
            private set;
        }
    }
}
