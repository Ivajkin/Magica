using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicaXNAClient
{
    class Singleton<T> where T : Singleton<T>
    {
        public Singleton()
        {
            pSingleton = (T)this;
        }
        public static T pSingleton { get; private set; }
    }
}
