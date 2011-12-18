using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MagicaXNAClient
{
    class Decal : Sprite
    {
        public Decal()
        {
            decalPosition = ++count;
        }
        public override float getCameraDistance()
        {
            float atTheGoundPosition = 99999999 - decalPosition;
            return atTheGoundPosition;
        }
        private int decalPosition;
        static private int count = 1;
    }
}
