using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace MagicaXNAClient
{
    class Input
    {
        internal MouseState getMouseState()
        {
            return Mouse.GetState();
        }
    }
}