using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MagicaXNAClient
{
    abstract class Updatable
    {
        public Updatable()
        {
            updatables.Add(this);
        }
        static private List<Updatable> updatables = new List<Updatable>();
        public static void UpdateAll(GameTime time)
        {
            foreach(Updatable obj in updatables) {
                obj.Update(time);
            }
        }

        abstract protected void Update(GameTime time);
    }
}
