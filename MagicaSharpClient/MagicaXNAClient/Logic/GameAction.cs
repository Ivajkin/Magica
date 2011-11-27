using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace MagicaXNAClient
{
    abstract class GameAction
    {
        abstract internal void Run(Vector2 position, GameObject postObject);
    }
}
