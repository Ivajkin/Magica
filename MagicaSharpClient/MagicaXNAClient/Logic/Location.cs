using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicaXNAClient
{
    class Location
    {
        public Location(LocationType type)
        {
            type.createBackground();
            type.generateDoodards();

            this.type = type;
        }
        private List<Doodard> doodards = new List<Doodard>();
        private LocationType type = null;
    }
}
